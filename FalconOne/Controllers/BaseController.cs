using FalconeOne.BLL.Helpers;
using FalconOne.API.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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

        protected IActionResult AppResponse(ApiResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                case HttpStatusCode.NoContent:
                    return NoContent();
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.Accepted:
                    return Accepted(response);
                case HttpStatusCode.InternalServerError:
                    return BadRequest();
                case HttpStatusCode.BadRequest:
                    return BadRequest();
                case HttpStatusCode.Created:
                    return Created(GetRequestURI(), null);
                default:
                    return NoContent();
            }
        }

        private string GetRequestURI()
        {
            var uri = HttpContext.Request.GetDisplayUrl();

            return uri ?? HttpContext.Request.Path;
        }
    }
}
