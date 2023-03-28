using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Utilities.DTOs;

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
    }
}
