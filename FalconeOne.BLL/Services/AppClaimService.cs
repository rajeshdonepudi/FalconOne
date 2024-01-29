using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Account;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace FalconeOne.BLL.Services
{
    public class AppClaimService : BaseService, IAppClaimService
    {
        private readonly RoleManager<SecurityRole> _roleManager;

        public AppClaimService(UserManager<User> userManager, RoleManager<SecurityRole> roleManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITenantService tenantService)
            : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateClaimAsync(UserClaimDto model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            await _unitOfWork.SecurityClaimsRepository.AddAsync(new SecurityClaim
            {
                Type = model.Type,
                Value = model.Value,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                ApplicationPolicyId = model.PolicyId is null ? Guid.Empty : Guid.Parse(model.PolicyId)
            }, CancellationToken.None);

            var result = await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddClaimToRoleAsync(AddClaimToRoleDto model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var role = await _roleManager.FindByIdAsync(model.RoleId);

            var claim = await _unitOfWork.SecurityClaimsRepository.FindAsync(x => x.Id == model.ClaimId, CancellationToken.None);

            if (role is null || claim is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var result = await _roleManager.AddClaimAsync(role, new Claim(claim.Type, claim.Value));

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<bool> AddClaimToUserAsync(AddClaimToUserDto model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            var claim = await _unitOfWork.SecurityClaimsRepository.FindAsync(x => x.Id == model.ClaimId, CancellationToken.None);

            if (user is null || claim is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var result = await _userManager.AddClaimAsync(user, new Claim(claim.Type, claim.Value));

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<bool> AddClaimsToUserAsync(AddClaimsToUserDto model)
        {
            if (model is null)
            {
                throw new ApiException(ErrorMessages.INVALID_REQUEST);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                throw new ApiException(ErrorMessages.SOMETHING_WENT_WRONG);
            }

            var claims = new List<Claim>();

            foreach (Guid claimId in model.Claims)
            {
                var claim = await _unitOfWork.SecurityClaimsRepository.FindAsync(x => x.Id == claimId, CancellationToken.None);

                claims.Add(new Claim(claim.Type, claim.Value));
            }

            var result = await _userManager.AddClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                throw new ApiException(FormatIdentityErrors(result.Errors));
            }
            return result.Succeeded;
        }

        public async Task<IEnumerable<string>> GetAllClaimsAsync()
        {
            var result = await _unitOfWork.SecurityClaimsRepository.GetAllAsync(CancellationToken.None);

            var claims = result.Select(x => x.Type).ToList();

            return claims;
        }

        public async Task<bool> DeleteClaimAsync(Guid guid)
        {
            var claim = await _unitOfWork.SecurityClaimsRepository.GetByIdAsync(guid, CancellationToken.None);

            _unitOfWork.SecurityClaimsRepository.Remove(claim);

            var result = await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }

}
