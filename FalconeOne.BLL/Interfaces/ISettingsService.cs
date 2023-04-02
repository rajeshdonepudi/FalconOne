using FalconeOne.BLL.Helpers;
using Utilities.DTOs;
using Utilities.Enumerations;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISettingsService
    {
        Task<ApiResponse> GetSettings(SettingTypeEnum settingType);
        Task<ApiResponse> AddNewSetting(ApplicationSettingDTO model);
        Task<ApiResponse> DeleteSetting(Guid id);
    }
}
