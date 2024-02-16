using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.Extensions.Caching.Memory;
using FalconOne.Extensions.EntityFramework;

namespace FalconOne.DAL.Repositories
{
    public class SystemLogsRepository : GenericRepository<SystemLog>, ISystemLogRepository
    {
        public SystemLogsRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache) { }

        public async Task<PagedList<SystemLog>> GetAllRequestInfoPaginatedAsync(PageParams pageParams, CancellationToken cancellationToken)
        {
            var records = await _context.SystemLogs.ToPagedListAsync(pageParams);

            return records;
        }
    }
}

