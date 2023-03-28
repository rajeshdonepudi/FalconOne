using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class AppPolicyService : BaseService, IAppPolicyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AppPolicyService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork) : base(userManager, mapper, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreatePolicy(CreatePolicyDTO model)
        {
            var policy = _mapper.Map<ApplicationPolicy>(model);

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
            var result = await _unitOfWork.ApplicationPolicyRepository.GetQuery().Include(x => x.PolicyClaims).ToListAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }

        #region Private
        private async Task DeleteAssociatedClaims(Guid policyId)
        {
            var claims = await _unitOfWork.UserClaimRepository.GetQuery().Where(x => x.ApplicationPolicyId == policyId).ToListAsync();

            foreach (var claim in claims)
            {
                await _unitOfWork.UserClaimRepository.DeleteAsync(claim);
            }
        }
        #endregion
    }
}
