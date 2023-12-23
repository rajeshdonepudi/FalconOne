using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(FalconOneContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

        public async Task<IEnumerable<Department>> GetDepartmentsByTenantId(Guid tenantId, CancellationToken cancellationToken)
        {
            return await _context.Departments.Where(x => x.LocationId == tenantId)
                                             .ToListAsync(cancellationToken);
        }
    }
}

