using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedSettingsController : BaseSecureController
    {
        private readonly IAdvancedSettingsService _advancedSettingsService;

        public AdvancedSettingsController(IAdvancedSettingsService advancedSettingsService)
        {
            _advancedSettingsService = advancedSettingsService;
        }

        [HttpPost("hash-password")]
        [ResourceIdentifier(ResourceCodes.ResourceIdentifier.Settings.HASH_PASSWORD)]
        public async Task<IActionResult> HashPassword(string password)
        {
            var result = await _advancedSettingsService.HashPasswordAsync(password);

            return Ok(result);
        }
    }
}
