using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedSettingsController : BaseController
    {
        private readonly IAdvancedSettingsService _advancedSettingsService;

        public AdvancedSettingsController(IAdvancedSettingsService advancedSettingsService)
        {
            _advancedSettingsService = advancedSettingsService;
        }

        [HttpPost("hash-password")]
        public async Task<IActionResult> HashPassword(string password)
        {
            var result = await _advancedSettingsService.HashPasswordAsync(password);

            return Ok(result);
        }
    }
}
