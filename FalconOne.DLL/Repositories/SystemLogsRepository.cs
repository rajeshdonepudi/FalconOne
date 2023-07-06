using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class SystemLogsRepository : GenericRepository<SystemLog>, ISystemLogRepository
    {
        public SystemLogsRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache) { }

        public async Task<PagedList<SystemLog>> GetAllRequestInfoPaginatedAsync(PageParams pageParams, CancellationToken cancellationToken)
        {
            long total = await _context.SystemLogs.LongCountAsync(cancellationToken);

            List<SystemLog> records = await _context.SystemLogs
                                                    .Skip((pageParams.PageIndex - 1) * pageParams.PageSize)
                                                    .Take(pageParams.PageSize)
                                                    .ToListAsync(cancellationToken);

            return new PagedList<SystemLog>(records, total, pageParams.PageIndex, pageParams.PageSize);
        }
    }
}

