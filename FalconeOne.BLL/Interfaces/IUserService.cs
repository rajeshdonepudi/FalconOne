using FalconeOne.BLL.Helpers;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.DTOs.Users;

namespace FalconeOne.BLL.Interfaces
{
    public interface IUserService
    {
        Task<PagedListDTO> GetAllAsync(PageParams model);
        Task<ApiResponse> GetDashboardInfo();
        Task<UserDto> GetByIdAsync(string userId);
        Task<bool> UpdateUserAsync(int id, SignupRequestDto model);
        Task<bool> DeleteAsync(string userId);
        Task<bool> AddUserToRoleAsync(AddToRoleDto model);
        Task<bool> AddUser(AddUserDto model);
    }
}
