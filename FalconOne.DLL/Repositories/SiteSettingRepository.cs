using FalconOne.DAL.Contracts;
using FalconOne.Enumerations.Settings;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FalconOne.DAL.Repositories
{
    public class SiteSettingRepository : GenericRepository<SiteSetting>, ISiteSettingRepository
    {
        public SiteSettingRepository(FalconOneContext falconOneContext, IMemoryCache memoryCache) : base(falconOneContext, memoryCache)
        {
        }

        public async Task<IEnumerable<SiteSetting>> GetTenantSiteSettingsByTypeAsync(SystemSettingTypeEnum type, Guid tenantId, CancellationToken cancellationToken, bool cacheRequest = false, int? cacheExpirationInSeconds = 200)
        {
            string key = string.Format(CacheKeyHelper.SiteSettings.TENANT_SITE_SETTINGS_BY_TYPE, tenantId, type);

            if (cacheRequest)
            {
                return await _memoryCache.GetOrCreateAsync(key, entry =>
                {
                    _ = entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheExpirationInSeconds.GetValueOrDefault()));

                    return _context.SiteSettings.Where(x => x.SettingType == type && x.TenantId == tenantId).ToListAsync(cancellationToken);
                });
            }
            else
            {
                return await _context.SiteSettings.Where(x => x.SettingType == type && x.TenantId == tenantId).ToListAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<SiteSetting>> GetSiteSettingsByTypeAsync(SystemSettingTypeEnum type, CancellationToken cancellationToken)
        {
            return await _context.SiteSettings.Where(x => x.SettingType == type).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<SiteSetting>> GetSiteSettingsByTenantIdAsync(Guid tenantId, CancellationToken cancellationToken, bool cacheRequest = false, int? cacheExpirationInSeconds = 200)
        {
            string key = string.Format(CacheKeyHelper.SiteSettings.TENANT_SITE_SETTINGS, tenantId);

            if (cacheRequest)
            {
                return await _memoryCache.GetOrCreateAsync(key, entry =>
                {
                    _ = entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheExpirationInSeconds.GetValueOrDefault()));

                    return _context.SiteSettings.Where(x => x.TenantId == tenantId).AsNoTracking().ToListAsync(cancellationToken);
                });
            }
            else
            {
                return await _context.SiteSettings.Where(x => x.TenantId == tenantId).AsNoTracking().ToListAsync(cancellationToken);
            }
        }

        public async Task<SiteSetting> GetSiteSettingByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.SiteSettings.FirstAsync(x => x.Name == name);
        }

        public async Task<SiteSetting> GetTenantSiteSettingByNameAsync(string name, Guid tenantId, CancellationToken cancellationToken, bool cacheRequest = false, int? cacheExpirationInSeconds = 200)
        {
            string key = string.Format(CacheKeyHelper.SiteSettings.TENANT_SITE_SETTINGS_BY_NAME, tenantId, name);

            if (cacheRequest)
            {
                return await _memoryCache.GetOrCreateAsync(key, entry =>
                {
                    _ = entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheExpirationInSeconds.GetValueOrDefault()));

                    return _context.SiteSettings.FirstAsync(x => x.Name == name && x.TenantId == tenantId, cancellationToken);
                });
            }
            else
            {
                return await _context.SiteSettings.FirstAsync(x => x.Name == name && x.TenantId == tenantId, cancellationToken);
            }
        }
    }
}

