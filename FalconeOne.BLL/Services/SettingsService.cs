using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Utilities.DTOs;
using Utilities.Enumerations;

namespace FalconeOne.BLL.Services
{
    public class SettingsService : BaseService, ISettingsService
    {
        public SettingsService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork) : base(userManager, mapper, unitOfWork)
        {
        }

        public async Task<ApiResponse> AddNewSetting(ApplicationSettingDTO model)
        {
            var setting = _mapper.Map<ApplicationSetting>(model);

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

            var result = _mapper.Map<List<ApplicationSettingDTO>>(settings);

            return new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result);
        }

        public async Task<ApiResponse> UpdateSettings(List<ApplicationSettingDTO> settings)
        {
            var result = _mapper.Map<List<ApplicationSetting>>(settings);

            await _unitOfWork.ApplicationSettingRepository.UpdateRangeAsync(result);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Accepted, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> UpdateSettingsByName(List<ApplicationSettingDTO> settings)
        {
            foreach (var setting in settings)
            {
                var settingToUpdate = await _unitOfWork.ApplicationSettingRepository.QueryAsync(x => x.Name == setting.Name);

                if(settingToUpdate != null)
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
