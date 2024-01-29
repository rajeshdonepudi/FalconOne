using FalconeOne.BLL.Interfaces;
using FalconOne.Models.DTOs.Account;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.Security
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
            var result = await _appClaimService.CreateClaimAsync(model);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("get-all-claims")]
        public async Task<IActionResult> GetAllClaims()
        {
            var result = await _appClaimService.GetAllClaimsAsync();

            return Ok(result);
        }

        [HttpDelete("delete-claim")]
        public async Task<IActionResult> DeleteClaimAsync(Guid claimId)
        {
            var result = await _appClaimService.DeleteClaimAsync(claimId);

            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
