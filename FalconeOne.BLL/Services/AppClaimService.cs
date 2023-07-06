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
        private readonly RoleManager<SecurityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AppClaimService(UserManager<User> userManager, RoleManager<SecurityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> CreateClaimAsync(UserClaimDto model)
        {
            await _unitOfWork.SecurityClaimsRepository.AddAsync(new SecurityClaim
            {
                Type = model.Type,
                Value = model.Value,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                ApplicationPolicyId = model.PolicyId is null ? Guid.Empty : Guid.Parse(model.PolicyId)
            }, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimToRoleAsync(AddClaimToRoleDto model)
        {
            SecurityRole role = await _roleManager.FindByIdAsync(model.RoleId);

            SecurityClaim res = await _unitOfWork.SecurityClaimsRepository.FindAsync(x => x.Id == model.ClaimId, CancellationToken.None);

            await _roleManager.AddClaimAsync(role, new Claim(res.Type, res.Value));

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimToUserAsync(AddClaimToUserDto model)
        {
            User user = await _userManager.FindByIdAsync(model.UserId);

            SecurityClaim res = await _unitOfWork.SecurityClaimsRepository.FindAsync(x => x.Id == model.ClaimId, CancellationToken.None);

            await _userManager.AddClaimAsync(user, new Claim(res.Type, res.Value));

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimsToUserAsync(AddClaimsToUserDto model)
        {
            User user = await _userManager.FindByIdAsync(model.UserId);

            List<Claim> claims = new();

            foreach (Guid claim in model.Claims)
            {
                SecurityClaim r = await _unitOfWork.SecurityClaimsRepository.FindAsync(x => x.Id == claim, CancellationToken.None);

                claims.Add(new Claim(r.Type, r.Value));
            }

            await _userManager.AddClaimsAsync(user, claims);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllClaimsAsync()
        {
            IEnumerable<SecurityClaim> result = await _unitOfWork.SecurityClaimsRepository.GetAllAsync(CancellationToken.None);

            List<string> claims = result.Select(x => x.Type).ToList();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, claims));
        }

        public async Task<ApiResponse> DeleteClaimAsync(Guid guid)
        {
            SecurityClaim claim = await _unitOfWork.SecurityClaimsRepository.GetByIdAsync(guid, CancellationToken.None);

            _unitOfWork.SecurityClaimsRepository.Remove(claim);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }
    }

}
