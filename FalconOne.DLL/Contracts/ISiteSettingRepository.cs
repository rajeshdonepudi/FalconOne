using FalconOne.Enumerations.Settings;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface ISiteSettingRepository : IGenericRepository<SiteSetting>
    {
        Task<IEnumerable<SiteSetting>> GetSiteSettingsByTenantIdAsync(Guid tenantId);
        Task<IEnumerable<SiteSetting>> GetSiteSettingsByTypeAsync(SettingTypeEnum type);
        Task<SiteSetting> GetSiteSettingByNameAsync(string name);
        Task<IEnumerable<SiteSetting>> GetTenantSiteSettingsByTypeAsync(SettingTypeEnum type, Guid tenantId);
        Task<SiteSetting> GetTenantSiteSettingByNameAsync(string name, Guid tenantId);
    }
}
