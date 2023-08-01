using FalconOne.Enumerations.Settings;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface ISiteSettingRepository : IGenericRepository<SiteSetting>
    {
        Task<IEnumerable<SiteSetting>> GetSiteSettingsByTenantIdAsync(Guid tenantId, CancellationToken cancellationToken, bool cacheRequest = false, int? cacheExpirationInSeconds = 200);
        Task<IEnumerable<SiteSetting>> GetSiteSettingsByTypeAsync(SystemSettingTypeEnum type, CancellationToken cancellationToken);
        Task<SiteSetting> GetSiteSettingByNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<SiteSetting>> GetTenantSiteSettingsByTypeAsync(SystemSettingTypeEnum type, Guid tenantId, CancellationToken cancellationToken, bool cacheRequest = false, int? cacheExpirationInSeconds = 200);
        Task<SiteSetting> GetTenantSiteSettingByNameAsync(string name, Guid tenantId, CancellationToken cancellationToken, bool cacheRequest = false, int? cacheExpirationInSeconds = 200);
    }
}
