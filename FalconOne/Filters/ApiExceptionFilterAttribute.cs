using FalconOne.Helpers.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
}
