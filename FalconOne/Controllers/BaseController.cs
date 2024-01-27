using FalconOne.API.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace FalconOne.API.Controllers
{
    [ServiceFilter(typeof(AsyncActionFilter))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        public BaseController() : base()
        {
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

        protected string GetRequestURI()
        {
            var uri = HttpContext.Request.GetDisplayUrl();

            return uri ?? HttpContext.Request.Path;
        }
    }
}
