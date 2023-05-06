using System.Net;

namespace FalconeOne.BLL.Helpers
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode statuscode, string message)
        {
            Message = message;
            StatusCode = statuscode;
        }
        public ApiResponse(HttpStatusCode statuscode, string message, object response)
        {
            Message = message;
            Response = response;
            StatusCode = statuscode;
        }
        public ApiResponse(HttpStatusCode statuscode, string message, object response, object errors)
        {
            Message = message;
            Response = response;
            Errors = errors;
            StatusCode = statuscode;
        }

        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Response { get; set; }
        public object Errors { get; set; }
    }
}
