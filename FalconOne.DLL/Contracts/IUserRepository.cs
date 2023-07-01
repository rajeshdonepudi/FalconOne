using FalconOne.Helpers.Helpers;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<PagedList<User>> GetAllUsersByTenantIdPaginatedAsync(Guid tenantId, PageParams pageParams);

        Task<bool> IsUserNameAvailable(string username);
    }
}
