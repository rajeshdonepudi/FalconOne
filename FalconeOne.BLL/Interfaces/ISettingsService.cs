using FalconeOne.BLL.Helpers;
using Utilities.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISettingsService
    {
        Task<ApiResponse> AddNewSetting(ApplicationSettingDTO model);
        Task<ApiResponse> DeletSetting(Guid id);
    }
}
