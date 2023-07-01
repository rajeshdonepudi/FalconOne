using FalconeOne.BLL.Helpers;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> GetAllAsync(PageParams model);
        Task<ApiResponse> GetByIdAsync(string userId);
        Task<AuthenticateResponseDto> UpdateUserAsync(int id, SignupRequestDto model);
        Task<ApiResponse> DeleteAsync(string userId);
        Task<ApiResponse> AddUserToRoleAsync(AddToRoleDto model);
        Task<ApiResponse> UpdateEmailConfirmed(string userId, bool value);
    }
}
