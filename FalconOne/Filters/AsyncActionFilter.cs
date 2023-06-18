using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Extensions.Http;
using FalconOne.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FalconOne.API.Filters
{
    public class AsyncActionFilter : IAsyncActionFilter
    {
        private const string CONTROLLER_KEY = "controller";
        private const string ACTION_KEY = "action";

        #region Private methods
        private async Task LogToDatabase(ActionExecutingContext context)
        {
            IRequestInformationService requestInformationService = (IRequestInformationService)context.HttpContext.RequestServices.GetService(typeof(IRequestInformationService))!;
            ITenantService tenantService = (ITenantService)context.HttpContext.RequestServices.GetService(typeof(ITenantService))!;

            await requestInformationService!.SaveRequestInfoAsync(new RequestInformationDTO
            {
                TraceIdentifier = context.HttpContext.TraceIdentifier,
                Controller = context.RouteData.Values[CONTROLLER_KEY].ToString()!,
                Action = context.RouteData.Values[ACTION_KEY].ToString()!,
                ResourceCode = GetActionResourceCode(context),
                Method = context.HttpContext.Request.Method,
                Path = context.HttpContext.Request.Path,
                IP = context.HttpContext.GetRequestIP(true),
                Host = context.HttpContext.Request.Host.Host,
                Scheme = context.HttpContext.Request.Scheme,
                Protocol = context.HttpContext.Request.Protocol,
                Port = context.HttpContext.Request.Host.Port.GetValueOrDefault(),
                UserAgent = context.HttpContext.GetHeaderValueAs<string>("User-Agent"),
                RecordedOn = DateTime.UtcNow,
                TenantId = await tenantService.GetTenantId()
            });
        }
        #endregion

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await LogToDatabase(context);
            await next();
            await LogToDatabase(context);
        }

        private string GetActionResourceCode(ActionExecutingContext context)
        {
            MethodInfo? method = context.Controller.GetType().GetMethod(context.RouteData.Values[ACTION_KEY].ToString());
            ResourceIdentifierAttribute? myAttribute = method.GetCustomAttribute<ResourceIdentifierAttribute>();
            if (myAttribute is not null)
            {
                string code = myAttribute.ResourceCode;
                if (!string.IsNullOrEmpty(code))
                {
                    return code;
                }
                throw new Exception("Resource code not specified for the resource.");
            }
            throw new Exception("Unable to determine resource.");
        }
    }
}
