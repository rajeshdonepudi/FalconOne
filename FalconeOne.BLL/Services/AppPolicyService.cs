using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using System.Net;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class AppPolicyService : BaseService, IAppPolicyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AppPolicyService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
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

        public async Task<ApiResponse> GetAllPolicies()
        {
            var result = await _unitOfWork.ApplicationPolicyRepository.GetAllAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
