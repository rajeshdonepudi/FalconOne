using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppClaimService
    {
        Task<ApiResponse> AddClaimToRoleAsync(AddClaimToRoleDTO model);
        Task<ApiResponse> AddClaimToUserAsync(AddClaimToUserDTO model);
        Task<ApiResponse> AddClaimsToUserAsync(AddClaimsToUserDTO model);
        Task<ApiResponse> CreateClaimAsync(UserClaimDTO model);
        Task<ApiResponse> GetAllClaimsAsync();
        Task<ApiResponse> DeleteClaimAsync(Guid guid);
    }
}
