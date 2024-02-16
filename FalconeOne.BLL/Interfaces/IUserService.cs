using FalconeOne.BLL.Helpers;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Dtos.Common;
using FalconOne.Models.DTOs.Account;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;

namespace FalconeOne.BLL.Interfaces
{
    public interface IUserService
    {
        Task<PagedListDto> GetAllAsync(PageParams model);
        Task<PagedList<User>> GetAllAsync(PageParams model);
        Task<UserManagementDashboardInfoDto> GetDashboardInfo();
        Task<UserInfoDto> GetByIdAsync(string userId);
        Task<bool> UpdateUserAsync(int id, SignupRequestDto model);
        Task<bool> DeleteAsync(string userId);
        Task<bool> AddUserToRoleAsync(AddToRoleDto model);
        Task<bool> AddUser(AddUserDto model);
    }
}
