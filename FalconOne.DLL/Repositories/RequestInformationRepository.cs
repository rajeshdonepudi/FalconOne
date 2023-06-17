using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class RequestInformationRepository : GenericRepository<SystemLog>, IRequestInformationRepository
    {
        public RequestInformationRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<PagedList<SystemLog>> GetAllRequestInfoPaginatedAsync(PageParams pageParams)
        {
            long total = await _context.SystemLogs.LongCountAsync();

            List<SystemLog> records = await _context.SystemLogs
                                        .Skip((pageParams.PageIndex - 1) * pageParams.PageSize)
                                        .Take(pageParams.PageSize)
                                        .ToListAsync();

            return new PagedList<SystemLog>(records, total, pageParams.PageIndex, pageParams.PageSize);
        }
    }
}

