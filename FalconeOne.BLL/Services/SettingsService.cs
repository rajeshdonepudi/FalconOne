using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using FalconOne.Enumerations.Settings;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class SettingsService : BaseService, ISettingsService
    {
        public SettingsService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor ) : base(userManager, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<ApiResponse> AddNewSetting(ApplicationSettingDTO model)
        {
            var setting = new ApplicationSetting();

            setting.CreatedOn = DateTime.UtcNow;

            await _unitOfWork.ApplicationSettingRepository.AddAsync(setting);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> DeleteSetting(Guid id)
        {
            var setting = await _unitOfWork.ApplicationSettingRepository.QueryAsync(x => x.Id == id);

            await _unitOfWork.ApplicationSettingRepository.DeleteAsync(setting);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.NoContent, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetSettings(SettingTypeEnum settingType)
        {
            var settings = await _unitOfWork.ApplicationSettingRepository.QueryAllAsync(x => x.SettingType == settingType);

            var result = new List<ApplicationSettingDTO>();

            return new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result);
        }

        public async Task<ApiResponse> UpdateSettings(List<ApplicationSettingDTO> settings)
        {
            var result = new List<ApplicationSetting>();

            await _unitOfWork.ApplicationSettingRepository.UpdateRangeAsync(result);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> UpdateSettingsByName(List<ApplicationSettingDTO> settings)
        {
            foreach (var setting in settings)
            {
                var settingToUpdate = await _unitOfWork.ApplicationSettingRepository.QueryAsync(x => x.Name == setting.Name);

                if (settingToUpdate != null)
                {
                    settingToUpdate.Value = setting.Value;
                    await _unitOfWork.ApplicationSettingRepository.UpdateAsync(settingToUpdate);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }
    }
}
