using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class AppPolicyService : BaseService, IAppPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppPolicyService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITenantService tenantService) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreatePolicy(CreatePolicyDto model)
        {
            if (model is null)
            {
                throw new ApiException(MessageHelper.INVALID_REQUEST);
            }

            var policy = new SecurityPolicy()
            {
                Name = model.Name,
            };

            await _unitOfWork.ApplicationPolicyRepository.AddAsync(policy, CancellationToken.None);

            var result = await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePolicy(Guid id)
        {
            var policy = await _unitOfWork.ApplicationPolicyRepository.FindAsync(x => x.Id == id, CancellationToken.None);

            /*** Delete claims first */
            await DeleteAssociatedClaims(id);

            _unitOfWork.ApplicationPolicyRepository.Remove(policy);

            var result = await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<SecurityPolicy>> GetAllPolicies()
        {
            var result = await _unitOfWork.ApplicationPolicyRepository.GetAllSecurityPoliciesWithClaimsAsync(CancellationToken.None);

            return result;
        }

        #region Private
        private async Task DeleteAssociatedClaims(Guid policyId)
        {
            IEnumerable<SecurityClaim> claims = await _unitOfWork.SecurityClaimsRepository.GetSecurityClaimsByPolicyId(policyId, CancellationToken.None);

            foreach (SecurityClaim? claim in claims)
            {
                _unitOfWork.SecurityClaimsRepository.Remove(claim);
            }
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }
        #endregion
    }
}
