using FalconOne.DAL.Contracts;
using FalconOne.Enumerations.Settings;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class SiteSettingRepository : GenericRepository<SiteSetting>, ISiteSettingRepository
    {
        public SiteSettingRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<IEnumerable<SiteSetting>> GetTenantSiteSettingsByTypeAsync(SettingTypeEnum type, Guid tenantId)
        {
            return await _context.SiteSettings.Where(x => x.SettingType == type && x.TenantId == tenantId).ToListAsync();
        }

        public async Task<IEnumerable<SiteSetting>> GetSiteSettingsByTypeAsync(SettingTypeEnum type)
        {
            return await _context.SiteSettings.Where(x => x.SettingType == type).ToListAsync();
        }

        public async Task<IEnumerable<SiteSetting>> GetSiteSettingsByTenantIdAsync(Guid tenantId)
        {
            return await _context.SiteSettings.Where(x => x.TenantId == tenantId).ToListAsync();
        }

        public async Task<SiteSetting> GetSiteSettingByNameAsync(string name)
        {
            return await _context.SiteSettings.FirstAsync(x => x.Name == name);
        }

        public async Task<SiteSetting> GetTenantSiteSettingByNameAsync(string name, Guid tenantId)
        {
            return await _context.SiteSettings.FirstAsync(x => x.Name == name && x.TenantId == tenantId);
        }
    }
}

