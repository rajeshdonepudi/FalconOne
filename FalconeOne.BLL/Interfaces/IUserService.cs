using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs.Account;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;

namespace FalconeOne.BLL.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedList<UserInfoDto>> GetAllActiveAsync(PageParams model);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<UserManagementDashboardInfoDto> GetDashboardInfo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserInfoDto> GetByIdAsync(string userId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateUserAsync(int id, SignupRequestDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> AddUserToRoleAsync(AddToRoleDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpsertUser(UpsertUserDto model);

        Task<bool> RevokeAccess(string refreshToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceAlias"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteUserAsync(string resourceAlias, CancellationToken cancellationToken);

        Task<IEnumerable<UserCreatedByYearDTO>> UserCreatedByYears();
    }
}
