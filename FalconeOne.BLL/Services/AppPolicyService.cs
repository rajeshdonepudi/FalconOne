using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

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
        public async Task<ApiResponse> CreatePolicy(CreatePolicyDto model)
        {
            SecurityPolicy policy = new()
            {
                Name = model.Name,
            };

            await _unitOfWork.ApplicationPolicyRepository.AddAsync(policy, CancellationToken.None);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> DeletePolicy(Guid id)
        {
            SecurityPolicy policy = await _unitOfWork.ApplicationPolicyRepository.FindAsync(x => x.Id == id, CancellationToken.None);

            /*** Delete claims first */
            await DeleteAssociatedClaims(id);

            _unitOfWork.ApplicationPolicyRepository.Remove(policy);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllPolicies()
        {
            IEnumerable<SecurityPolicy> result = await _unitOfWork.ApplicationPolicyRepository.GetAllSecurityPoliciesWithClaimsAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }

        #region Private
        private async Task DeleteAssociatedClaims(Guid policyId)
        {
            IEnumerable<SecurityClaim> claims = await _unitOfWork.SecurityClaimsRepository.GetSecurityClaimsByPolicyId(policyId);

            foreach (SecurityClaim? claim in claims)
            {
                _unitOfWork.SecurityClaimsRepository.Remove(claim);
            }
        }
        #endregion
    }
}
