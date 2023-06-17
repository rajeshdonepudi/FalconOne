using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<IEnumerable<Department>> GetDepartmentsByTenantId(Guid tenantId)
        {
            return await _context.Departments.Where(x => x.TenantId == tenantId).ToListAsync();
        }
    }
}

