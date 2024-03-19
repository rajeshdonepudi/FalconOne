using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace FalconOne.API.Filters
{
    public class ApiResponseFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.StatusCode == (int) HttpStatusCode.OK)
            {
                objectResult.Value = new ApiSuccessResponse
                {
                    Message = MessageHelper.SuccessMessages.SUCESSFULL,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Data = objectResult.Value,
                };
                context.Result = objectResult;
            }
        }
    }
}
