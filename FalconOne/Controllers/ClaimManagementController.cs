using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimManagementController : BaseController
    {
        private readonly IAppClaimService _appClaimService;

        public ClaimManagementController(IAppClaimService appClaimService)
        {
            _appClaimService = appClaimService;
        }

        [HttpPost("create-new-claim")]
        public async Task<IActionResult> CreateNewClaim(UserClaimDto model)
        {
            if (ModelState.IsValid)
            {
                FalconeOne.BLL.Helpers.ApiResponse result = await _appClaimService.CreateClaimAsync(model);

                return AppResponse(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("get-all-claims")]
        public async Task<IActionResult> GetAllClaims()
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _appClaimService.GetAllClaimsAsync();

            return AppResponse(response);
        }

        [HttpDelete("delete-claim")]
        public async Task<IActionResult> DeleteClaimAsync(Guid claimId)
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _appClaimService.DeleteClaimAsync(claimId);

            return AppResponse(response);
        }
    }
}
