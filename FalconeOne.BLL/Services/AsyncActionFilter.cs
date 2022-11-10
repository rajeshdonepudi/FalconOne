using FalconeOne.BLL.DTOs;
using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace FalconeOne.BLL.Services
{
    public class AsyncActionFilter : IActionFilter
    {
        private const string CONTROLLER_KEY = "controller";
        private const string ACTION_KEY = "action";

        private string GetRequestIP(HttpContext context, bool tryUseXForwardHeader = true)
        {
            string ip = string.Empty;

            if (tryUseXForwardHeader)
                ip = SplitCsv(GetHeaderValueAs<string>(context, "X-Forwarded-For")).FirstOrDefault();

            if (string.IsNullOrEmpty(ip) && context?.Connection?.RemoteIpAddress != null)
                ip = context.Connection.RemoteIpAddress.MapToIPv4().ToString();

            if (string.IsNullOrEmpty(ip))
                ip = GetHeaderValueAs<string>(context, "REMOTE_ADDR");

            // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.

            if (string.IsNullOrEmpty(ip))
                throw new Exception("Unable to determine caller's IP.");

            return ip;
        }


        private T GetServiceFromContext<T>(ActionContext context, Type type)
        {
            return (T)context.HttpContext.RequestServices.GetService(type);
        }

        private T GetHeaderValueAs<T>(HttpContext context, string headerName)
        {
            StringValues values;

            if (context?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!string.IsNullOrEmpty(rawValues))
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }

        private static List<string> SplitCsv(string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var requestInformationService = (IRequestInformationService)context.HttpContext.RequestServices.GetService(typeof(IRequestInformationService));

            requestInformationService.SaveRequestInfoAsync(new RequestInformationDTO
            {
                TraceIdentifier = context.HttpContext.TraceIdentifier,
                Controller = context.RouteData.Values[CONTROLLER_KEY].ToString(),
                Action = context.RouteData.Values[ACTION_KEY].ToString(),
                ResourceCode = ResourceCodes.USER_CREATE,
                Method = context.HttpContext.Request.Method,
                Path = context.HttpContext.Request.Path,
                IP = GetRequestIP(context.HttpContext, true),
                Host = context.HttpContext.Request.Host.Host,
                Scheme = context.HttpContext.Request.Scheme,
                Protocol = context.HttpContext.Request.Protocol,
                Port = context.HttpContext.Request.Host.Port.GetValueOrDefault(),
                UserAgent = GetHeaderValueAs<string>(context.HttpContext, "User-Agent"),
                RecordedOn = DateTime.UtcNow
            });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var requestInformationService = (IRequestInformationService)context.HttpContext.RequestServices.GetService(typeof(IRequestInformationService));

            requestInformationService.SaveRequestInfoAsync(new RequestInformationDTO
            {
                TraceIdentifier = context.HttpContext.TraceIdentifier,
                Controller = context.RouteData.Values[CONTROLLER_KEY].ToString(),
                Action = context.RouteData.Values[ACTION_KEY].ToString(),
                ResourceCode = ResourceCodes.USER_CREATE,
                Method = context.HttpContext.Request.Method,
                Path = context.HttpContext.Request.Path,
                IP = GetRequestIP(context.HttpContext, true),
                Host = context.HttpContext.Request.Host.Host,
                Scheme = context.HttpContext.Request.Scheme,
                Protocol = context.HttpContext.Request.Protocol,
                Port = context.HttpContext.Request.Host.Port.GetValueOrDefault(),
                UserAgent = GetHeaderValueAs<string>(context.HttpContext, "User-Agent"),
                RecordedOn = DateTime.UtcNow
            });
        }
    }
}
