using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppClaimService
    {
        Task<ApiResponse> AddClaimToRoleAsync(AddClaimToRoleDto model);
        Task<ApiResponse> AddClaimToUserAsync(AddClaimToUserDto model);
        Task<ApiResponse> AddClaimsToUserAsync(AddClaimsToUserDto model);
        Task<ApiResponse> CreateClaimAsync(UserClaimDto model);
        Task<ApiResponse> GetAllClaimsAsync();
        Task<ApiResponse> DeleteClaimAsync(Guid guid);
    }
}
