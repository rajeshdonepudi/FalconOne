using FalconeOne.BLL.Helpers;
using FalconOne.Enumerations.Settings;
using FalconOne.Models.DTOs.Settings;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISiteSettingsService
    {
        Task<ApiResponse> GetSettingTypes();
        Task<ApiResponse> GetSettings(SystemSettingTypeEnum settingType);
        Task<ApiResponse> GetTenantSettings();
        Task<ApiResponse> AddNewSetting(AddSiteSettingDto model);
        Task<ApiResponse> DeleteSetting(Guid id);
        Task<ApiResponse> UpdateSettings(List<UpdateSiteSettingDto> settings);
        Task<ApiResponse> UpdateSettingsByName(List<UpdateSiteSettingDto> settings);
    }
}
