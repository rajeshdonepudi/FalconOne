using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Enumerations.Settings;
using FalconOne.Extensions.Enumerations;
using FalconOne.Models.DTOs.Settings;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class SiteSettingsService : BaseService, ISiteSettingsService
    {
        public SiteSettingsService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            ITenantService tenantService) :
            base(userManager,
                unitOfWork,
                httpContextAccessor,
                configuration,
                tenantService)
        {
        }

        public async Task<ApiResponse> AddNewSetting(AddSiteSettingDto model)
        {
            SiteSetting setting = new()
            {
                Name = model.Name,
                Value = model.Value,
                Description = model.Description,
                SettingType = model.SettingType,
                CreatedOn = DateTime.UtcNow,
                DisplayName = model.DisplayName,
                TenantId = await _tenantService.GetTenantId(),
            };

            await _unitOfWork.ApplicationSettingRepository.AddAsync(setting, CancellationToken.None);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> DeleteSetting(Guid id)
        {
            SiteSetting setting = await _unitOfWork.ApplicationSettingRepository.FindAsync(x => x.Id == id, CancellationToken.None);

            _unitOfWork.ApplicationSettingRepository.Remove(setting);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.NoContent, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetSettings(SystemSettingTypeEnum settingType)
        {
            IEnumerable<SiteSetting> settings = await _unitOfWork.ApplicationSettingRepository.GetTenantSiteSettingsByTypeAsync(settingType, await _tenantService.GetTenantId(), CancellationToken.None);

            List<SiteSettingDto> result = new();

            foreach (SiteSetting setting in settings)
            {
                result.Add(new SiteSettingDto
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

        public async Task<ApiResponse> GetSettingTypes()
        {
            List<KeyValuePair<string, int>> settingTypes = EnumExtensions.GetEnumKeyValuePairList<SystemSettingTypeEnum, string, int>();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, settingTypes));
        }

        public async Task<ApiResponse> GetTenantSettings()
        {
            var tenantSettings = await _unitOfWork.ApplicationSettingRepository.GetSiteSettingsByTenantIdAsync(await _tenantService.GetTenantId(), CancellationToken.None);

            var settings = tenantSettings.GroupBy(x => x.SettingType.GetDescription()).Select(x => new TenantSettingsResponse
            {
                SettingType = x.Key,
                Settings = x.Select(x => new TenantSettingDto { Key = x.Name, Type = (int)x.SettingType, Value = x.Value, DisplayName = x.DisplayName, Id = x.Id }).ToList()
            }).ToList();

            return new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, settings);
        }

        public async Task<ApiResponse> UpdateSettings(List<UpdateSiteSettingDto> settings)
        {
            List<SiteSetting> result = new();

            _unitOfWork.ApplicationSettingRepository.UpdateRange(result);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> UpdateSettingsByName(List<UpdateSiteSettingDto> settings)
        {
            foreach (UpdateSiteSettingDto setting in settings)
            {
                SiteSetting settingToUpdate = await _unitOfWork.ApplicationSettingRepository.GetTenantSiteSettingByNameAsync(setting.Name, await _tenantService.GetTenantId(), CancellationToken.None);

                if (settingToUpdate != null)
                {
                    settingToUpdate.Value = setting.Value;
                    _unitOfWork.ApplicationSettingRepository.Update(settingToUpdate);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                }
            }
            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }
    }
}
