using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utilities.DTOs;

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
        public async Task<IActionResult> CreateNewClaim(UserClaimDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appClaimService.CreateClaimAsync(model);

                return ReturnResponse(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("get-all-claims")]
        public async Task<IActionResult> GetAllClaims()
        {
            var response = await _appClaimService.GetAllClaimsAsync();

            return ReturnResponse(response);
        }

        [HttpDelete("delete-claim")]
        public async Task<IActionResult> DeleteClaimAsync(Guid claimId)
        {
            var response = await _appClaimService.DeleteClaimAsync(claimId);

            return ReturnResponse(response);
        }
    }
}
