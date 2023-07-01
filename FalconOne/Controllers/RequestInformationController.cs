﻿using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Helpers.Helpers;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInformationController : BaseController
    {
        private readonly ISystemLogsService _requestInformationService;

        public RequestInformationController(ISystemLogsService requestInformationService)
        {
            _requestInformationService = requestInformationService;
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.Account.NEW_USER_SIGNUP)]
        public async Task<IActionResult> GetAll([FromQuery] PageParams model)
        {
            return ReturnResponse(await _requestInformationService.GetAllAsync(model));
        }
    }
}
