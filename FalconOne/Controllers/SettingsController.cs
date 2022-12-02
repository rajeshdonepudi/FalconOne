using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities.DTOs;

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

        [HttpPost("add-new")]
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

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSetting(string guid)
        {
            bool validId = Guid.TryParse(guid, out var settingId);

            if (validId)
            {
                var response = await _settingsService.DeletSetting(settingId);
                return ReturnResponse(response);
            }
            else
            {
                return BadRequest(MessageHelper.INVALID_REQUEST);
            }
        }
    }
}
