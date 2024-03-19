using FalconOne.Helpers.Helpers;
using FalconOne.Models.Contracts;
using FalconOne.Models.DTOs.Security;
using FalconOne.Models.DTOs.Users;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<PagedList<UserInfoDto>> GetAllUsersByTenantIdPaginatedAsync(Guid tenantId, PageParams pageParams, CancellationToken cancellationToken);
        Task<bool> IsUserNameAvailable(string username, CancellationToken cancellationToken);
        Task<User> GetTenantUserInfoByEmail(Guid tenantId, string email, CancellationToken cancellationToken);
        Task<User> GetUserInfoByEmail(string email, CancellationToken cancellationToken);
        Task<User> GetUserByResourceAlias(string resourceAlias, CancellationToken cancellationToken);
        Task<UserInfoDto> GetUserInfoByResourceAlias(string resourceAlias, CancellationToken cancellationToken);
        Task<UserManagementDashboardInfoDto> GetUserManagementDashboardInfoByTenantId(Guid tenantId, CancellationToken cancellationToken);
        Task<List<SecurityRole>> GetUserRoles(Guid tenantId, Guid userId, CancellationToken cancellationToken);
    }
}
