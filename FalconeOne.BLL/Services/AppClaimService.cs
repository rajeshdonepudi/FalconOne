using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;

namespace FalconeOne.BLL.Services
{
    public class AppClaimService : IAppClaimService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AppClaimService(UserManager<User> userManager, RoleManager<UserRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> CreateClaimAsync(UserClaimDTO model)
        {
            await _unitOfWork.UserClaimsRepository.AddAsync(new SecurityClaim
            {
                Type = model.Type,
                Value = model.Value,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                ApplicationPolicyId = model.PolicyId is null ? Guid.Empty : Guid.Parse(model.PolicyId)
            });
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimToRoleAsync(AddClaimToRoleDTO model)
        {
            UserRole role = await _roleManager.FindByIdAsync(model.RoleId);

            SecurityClaim res = await _unitOfWork.UserClaimsRepository.FindAsync(x => x.Id == model.ClaimId);

            await _roleManager.AddClaimAsync(role, new Claim(res.Type, res.Value));

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimToUserAsync(AddClaimToUserDTO model)
        {
            User user = await _userManager.FindByIdAsync(model.UserId);

            SecurityClaim res = await _unitOfWork.UserClaimsRepository.FindAsync(x => x.Id == model.ClaimId);

            await _userManager.AddClaimAsync(user, new Claim(res.Type, res.Value));

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimsToUserAsync(AddClaimsToUserDTO model)
        {
            User user = await _userManager.FindByIdAsync(model.UserId);

            List<Claim> claims = new();

            foreach (Guid claim in model.Claims)
            {
                SecurityClaim r = await _unitOfWork.UserClaimsRepository.FindAsync(x => x.Id == claim);

                claims.Add(new Claim(r.Type, r.Value));
            }

            await _userManager.AddClaimsAsync(user, claims);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllClaimsAsync()
        {
            IEnumerable<SecurityClaim> result = await _unitOfWork.UserClaimsRepository.GetAllAsync();

            List<string> claims = result.Select(x => x.Type).ToList();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, claims));
        }

        public async Task<ApiResponse> DeleteClaimAsync(Guid guid)
        {
            SecurityClaim claim = await _unitOfWork.UserClaimsRepository.GetByIdAsync(guid);

            _unitOfWork.UserClaimsRepository.Remove(claim);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }
    }

}
