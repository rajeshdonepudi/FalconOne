using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Enumerations.Settings;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class SettingsService : BaseService, ISettingsService
    {
        public SettingsService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResponse> AddNewSetting(ApplicationSettingDTO model)
        {
            SiteSetting setting = new();

            setting.CreatedOn = DateTime.UtcNow;

            await _unitOfWork.ApplicationSettingRepository.AddAsync(setting);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> DeleteSetting(Guid id)
        {
            SiteSetting setting = await _unitOfWork.ApplicationSettingRepository.FindAsync(x => x.Id == id);

            _unitOfWork.ApplicationSettingRepository.Remove(setting);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.NoContent, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetSettings(SettingTypeEnum settingType)
        {
            IEnumerable<SiteSetting> settings = await _unitOfWork.ApplicationSettingRepository.GetApplicationSettingsByTypeAsync(settingType);

            List<ApplicationSettingDTO> result = new();

            foreach (SiteSetting setting in settings)
            {
                result.Add(new ApplicationSettingDTO
                {
                    SettingType = setting.SettingType,
                    Description = setting.Description,
                    Id = setting.Id,
                    Name = setting.Name,
                    Value = setting.Value,
                });
            }

            return new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result);
        }

        public async Task<ApiResponse> UpdateSettings(List<ApplicationSettingDTO> settings)
        {
            List<SiteSetting> result = new();

            _unitOfWork.ApplicationSettingRepository.UpdateRange(result);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> UpdateSettingsByName(List<ApplicationSettingDTO> settings)
        {
            foreach (ApplicationSettingDTO setting in settings)
            {
                SiteSetting settingToUpdate = await _unitOfWork.ApplicationSettingRepository.FindAsync(x => x.Name == setting.Name);

                if (settingToUpdate != null)
                {
                    settingToUpdate.Value = setting.Value;
                    _unitOfWork.ApplicationSettingRepository.Update(settingToUpdate);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }
    }
}
