using FalconOne.Helpers.Helpers;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IRequestInformationRepository : IGenericRepository<SystemLog>
    {
        Task<PagedList<SystemLog>> GetAllRequestInfoPaginatedAsync(PageParams pageParams);
    }
}
