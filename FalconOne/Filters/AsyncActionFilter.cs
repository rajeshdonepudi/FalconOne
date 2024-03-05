using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.Dtos.System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FalconOne.API.Filters
{
    public class AsyncActionFilter : IAsyncActionFilter
    {
        private const string CONTROLLER_KEY = "controller";
        private const string ACTION_KEY = "action";

        #region Private methods
        private async Task LogInfo(ActionExecutingContext context)
        {
            var requestInformationService = (ISystemLogsService)context.HttpContext.RequestServices.GetService(typeof(ISystemLogsService))!;
            var tenantService = (ITenantProvider)context.HttpContext.RequestServices.GetService(typeof(ITenantProvider))!;

            var info = new RequestInformationDto
            {
                TraceIdentifier = context.HttpContext.TraceIdentifier,
                Controller = context.RouteData.Values[CONTROLLER_KEY]?.ToString() ?? string.Empty,
                Action = context.RouteData.Values[ACTION_KEY]?.ToString() ?? string.Empty,
                ResourceCode = GetResourceIdentifier(context),
                Method = context.HttpContext.Request.Method,
                Path = context.HttpContext.Request.Path,
                IP = context.HttpContext?.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? string.Empty,
                Host = context.HttpContext?.Request.Host.Host ?? string.Empty,
                Scheme = context.HttpContext?.Request.Scheme ?? string.Empty,
                Protocol = context.HttpContext?.Request.Protocol ?? string.Empty,
                Port = context.HttpContext?.Request.Host.Port.GetValueOrDefault() ?? 0,
                UserAgent = context.HttpContext?.Request.Headers["User-Agent"].FirstOrDefault() ?? string.Empty,
                RecordedOn = DateTime.UtcNow,
                TenantId = await tenantService.GetTenantId()
            };

            await requestInformationService!.SaveRequestInfoAsync(info);
        }
        #endregion

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await LogInfo(context);
            await next();
            await LogInfo(context);
        }

        private string GetResourceIdentifier(ActionExecutingContext context)
        {
            MethodInfo? method = context.Controller.GetType().GetMethod(context.RouteData.Values[ACTION_KEY]?.ToString() ?? string.Empty);
            ResourceIdentifierAttribute? myAttribute = method?.GetCustomAttribute<ResourceIdentifierAttribute>();

            if (myAttribute is not null)
            {
                string code = myAttribute.ResourceCode;
                if (!string.IsNullOrEmpty(code))
                {
                    return code;
                }
                throw new Exception("Resource identifier not specified for the requested resource.");
            }
            throw new Exception("Unable to determine resource.");
        }
    }
}
