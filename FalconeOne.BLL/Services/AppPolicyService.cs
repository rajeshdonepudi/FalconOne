using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class AppPolicyService : BaseService, IAppPolicyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppPolicyService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(userManager, unitOfWork, httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse> CreatePolicy(CreatePolicyDTO model)
        {
            var policy = new ApplicationPolicy
            {
                Name = model.Name,
            };

            await _unitOfWork.ApplicationPolicyRepository.AddAsync(policy);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> DeletePolicy(Guid id)
        {
            var policy = await _unitOfWork.ApplicationPolicyRepository.QueryAsync(x => x.Id == id);

            /*** Delete claims first */
            await DeleteAssociatedClaims(id);

            await _unitOfWork.ApplicationPolicyRepository.DeleteAsync(policy);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllPolicies()
        {
            var result = await _unitOfWork.ApplicationPolicyRepository.GetQueryable().Include(x => x.PolicyClaims).ToListAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }

        #region Private
        private async Task DeleteAssociatedClaims(Guid policyId)
        {
            var claims = await _unitOfWork.UserClaimRepository.GetQueryable().Where(x => x.ApplicationPolicyId == policyId).ToListAsync();

            foreach (var claim in claims)
            {
                await _unitOfWork.UserClaimRepository.DeleteAsync(claim);
            }
        }
        #endregion
    }
}
