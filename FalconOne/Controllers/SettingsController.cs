﻿using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Constants;
using Utilities.DTOs;
using Utilities.Enumerations;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet("type/{settingType}")]
        [AllowAnonymous]
        [UserAction(resourceCode: ResourceCodes.GET_SETTING_BY_TYPE)]
        public async Task<IActionResult> GetSettings(SettingTypeEnum settingType)
        {
            return Ok(await _settingsService.GetSettings(settingType));
        }

        [HttpPost("add-new")]
        [Authorize(Policy = "SomePolicy")]
        public async Task<IActionResult> AddNewSetting(ApplicationSettingDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _settingsService.AddNewSetting(model);
                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        [AllowAnonymous]
        [UserAction(resourceCode: ResourceCodes.UPDATE_SETTINGS)]
        public async Task<IActionResult> UpdateSettings(List<ApplicationSettingDTO> settings)
        {
            return ReturnResponse(await _settingsService.UpdateSettingsByName(settings));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSetting(string guid)
        {
            bool validId = Guid.TryParse(guid, out var settingId);

            if (validId)
            {
                var response = await _settingsService.DeleteSetting(settingId);
                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(MessageHelper.INVALID_REQUEST);
            }
        }
    }
}
