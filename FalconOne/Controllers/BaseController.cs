using FalconOne.API.Filters;
using FalconOne.Models.DTOs.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace FalconOne.API.Controllers
{
    [ServiceFilter(typeof(AsyncActionFilter))]
    [ProducesResponseType(typeof(ApiErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ApiController]
    public class BaseController : Controller
    {
        protected string GetRequestURI()
        {
            var uri = HttpContext.Request.GetDisplayUrl();

            return uri ?? HttpContext.Request.Path;
        }

        protected void AddResponseHeader(string key, string value)
        {
            if (Response.Headers[key].ToString() != null)
            {
                Response.Headers[key] = value;
            }
            else
            {
                Response.Headers.Add(key, value);
            }
        }
    }
}
