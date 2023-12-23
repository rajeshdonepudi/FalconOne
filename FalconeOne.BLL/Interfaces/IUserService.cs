using FalconeOne.BLL.Helpers;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.DTOs.Users;

namespace FalconeOne.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> GetAllAsync(PageParams model);
        Task<ApiResponse> GetDashboardInfo();
        Task<ApiResponse> GetByIdAsync(string userId);
        Task<LoginResponseDto> UpdateUserAsync(int id, SignupRequestDto model);
        Task<ApiResponse> DeleteAsync(string userId);
        Task<ApiResponse> AddUserToRoleAsync(AddToRoleDto model);
        Task<ApiResponse> UpdateEmailConfirmed(string userId, bool value);
        Task<ApiResponse> AddUser(AddUserDto model);
    }
}
