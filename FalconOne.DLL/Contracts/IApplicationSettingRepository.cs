using FalconOne.Enumerations.Settings;
using FalconOne.Models.Contracts;
using FalconOne.Models.Entities;

namespace FalconOne.DAL.Contracts
{
    public interface IApplicationSettingRepository : IGenericRepository<SiteSetting>
    {
        Task<IEnumerable<SiteSetting>> GetApplicationSettingsByTypeAsync(SettingTypeEnum type);
    }
}
