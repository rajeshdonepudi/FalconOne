using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Extensions.Http;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FalconOne.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Log the exception if needed
            // You can use a logging framework like Serilog, NLog, etc.

            switch (context.Exception)
            {
                case ApiException:
                    var errorResponse = new
                    {
                        error = new
                        {
                            message = context.Exception.Message
                        }
                    };
                    context.Result = new BadRequestObjectResult(errorResponse);
                    context.ExceptionHandled = true;
                break;
            }
        }
    }

    public class AsyncActionFilter : IAsyncActionFilter
    {
        private const string CONTROLLER_KEY = "controller";
        private const string ACTION_KEY = "action";

        #region Private methods
        private async Task LogToDatabase(ActionExecutingContext context)
        {
            ISystemLogsService requestInformationService = (ISystemLogsService)context.HttpContext.RequestServices.GetService(typeof(ISystemLogsService))!;
            ITenantService tenantService = (ITenantService)context.HttpContext.RequestServices.GetService(typeof(ITenantService))!;

            await requestInformationService!.SaveRequestInfoAsync(new RequestInformationDto
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
                throw new Exception("Resource identifier not specified for the requested resource.");
            }
            throw new Exception("Unable to determine resource.");
        }
    }
}
