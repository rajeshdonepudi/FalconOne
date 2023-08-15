using FalconOne.Helpers.Helpers;
using FalconOne.Models.Contracts;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<PagedList<User>> GetAllUsersByTenantIdPaginatedAsync(Guid tenantId, PageParams pageParams, CancellationToken cancellationToken);

        Task<bool> IsUserNameAvailable(string username, CancellationToken cancellationToken);

        Task<User> GetTenantUserInfoByEmail(Guid tenantId, string email, CancellationToken cancellationToken);

        Task<UserManagementDashboardInfo> GetUserManagementDashboardInfoByTenantId(Guid tenantId, CancellationToken cancellationToken);
    }
}
