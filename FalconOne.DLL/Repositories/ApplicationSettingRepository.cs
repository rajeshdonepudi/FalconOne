using FalconOne.DAL.Contracts;
using FalconOne.Enumerations.Settings;
using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL.Repositories
{
    public class ApplicationSettingRepository : GenericRepository<SiteSetting>, IApplicationSettingRepository
    {
        public ApplicationSettingRepository(FalconOneContext falconOneContext) : base(falconOneContext) { }

        public async Task<IEnumerable<SiteSetting>> GetApplicationSettingsByTypeAsync(SettingTypeEnum type)
        {
            return await _context.SiteSettings.Where(x => x.SettingType == type).ToListAsync();
        }
    }
}

