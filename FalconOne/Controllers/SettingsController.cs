using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Enumerations.Settings;
using FalconOne.Models.DTOs.Settings;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        private readonly ISiteSettingsService _settingsService;

        public SettingsController(ISiteSettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet("type/{settingType}")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.Settings.GET_SETTING_BY_TYPE)]
        public async Task<IActionResult> GetSettings(SystemSettingTypeEnum settingType)
        {
            return Ok(await _settingsService.GetSettings(settingType));
        }

        [HttpGet("types")]
        [Authorize(Policy = "Admin")]
        [ResourceIdentifier(AppResourceCodes.Settings.GET_SETTING_BY_TYPE)]
        public async Task<IActionResult> GetSettingTypes()
        {
            return Ok(await _settingsService.GetSettingTypes());
        }

        [HttpGet("tenant-settings")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.Settings.GET_TENANT_SETTINGS)]
        public async Task<IActionResult> GetTenantSettings()
        {
            return Ok(await _settingsService.GetTenantSettings());
        }

        [HttpPost("add-new")]
        [Authorize(Policy = "Admin")]
        [ResourceIdentifier(AppResourceCodes.Settings.ADD_NEW_SETTING)]
        public async Task<IActionResult> AddNewSetting(AddSiteSettingDto model)
        {
            if (ModelState.IsValid)
            {
                ApiResponse response = await _settingsService.AddNewSetting(model);
                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        [Authorize(Policy = "Admin")]
        [ResourceIdentifier(AppResourceCodes.Settings.UPDATE_SETTINGS)]
        public async Task<IActionResult> UpdateSettings(List<UpdateSiteSettingDto> settings)
        {
            return ReturnResponse(await _settingsService.UpdateSettingsByName(settings));
        }

        [HttpDelete("delete")]
        [Authorize(Policy = "Admin")]
        [ResourceIdentifier(AppResourceCodes.Settings.DELETE_SETTING)]
        public async Task<IActionResult> DeleteSetting(string guid)
        {
            bool validId = Guid.TryParse(guid, out Guid settingId);

            if (validId)
            {
                ApiResponse response = await _settingsService.DeleteSetting(settingId);
                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(MessageHelper.INVALID_REQUEST);
            }
        }
    }
}
