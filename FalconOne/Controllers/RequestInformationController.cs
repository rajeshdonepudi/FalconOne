using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utilities.Helpers;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInformationController : BaseController
    {
        private readonly IRequestInformationService _requestInformationService;

        public RequestInformationController(IRequestInformationService requestInformationService)
        {
            _requestInformationService = requestInformationService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] PageParams model)
        {
            return ReturnResponse(await _requestInformationService.GetAllAsync(model));
        }
    }
}
