using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;
using Utilities.DTOs;

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
            await _unitOfWork.UserClaimRepository.AddAsync(new ApplicationClaim
            {
                Name = model.Name,
                Type = model.Type
            });
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimToRoleAsync(AddClaimToRoleDTO model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            var res = await _unitOfWork.UserClaimRepository.FindAsync(x => x.Id == model.ClaimId);

            await _roleManager.AddClaimAsync(role, new Claim(res.Type, res.Name));

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimToUserAsync(AddClaimToUserDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            var res = await _unitOfWork.UserClaimRepository.FindAsync(x => x.Id == model.ClaimId);

            await _userManager.AddClaimAsync(user, new Claim(res.Type, res.Name));

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> AddClaimsToUserAsync(AddClaimsToUserDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            var claims = new List<Claim>();

            foreach (var claim in model.Claims)
            {
                var r = await _unitOfWork.UserClaimRepository.FindAsync(x => x.Id == claim);

                claims.Add(new Claim(r.Type, r.Name));
            }

            await _userManager.AddClaimsAsync(user, claims);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllClaimsAsync()
        {
            var result = await _unitOfWork.UserClaimRepository.GetAllAsync();

            var claims = result.Select(x => x.Name).ToList();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, claims));
        }
    }

}
