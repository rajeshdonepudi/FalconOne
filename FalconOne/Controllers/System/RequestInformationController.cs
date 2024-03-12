using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInformationController : BaseSecureController
    {
        private readonly ISystemLogsService _sysLogService;

        public RequestInformationController(ISystemLogsService logService)
        {
            _sysLogService = logService;
        }

        [HttpGet("get-all-logs")]
        [ResourceIdentifier(ResourceIdentifier.Logging.VIEW_SECURITY_LOGS)]
        public async Task<IActionResult> GetAll([FromQuery] PageParams model)
        {
            return Ok(await _sysLogService.GetAllAsync(model));
        }
    }
}
