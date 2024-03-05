using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("get-all")]
        [AllowAnonymous]
        [ResourceIdentifier(ResourceIdentifier.Account.NEW_USER_SIGNUP)]
        public async Task<IActionResult> GetAll([FromQuery] PageParams model)
        {
            return Ok(await _sysLogService.GetAllAsync(model));
        }
    }
}
