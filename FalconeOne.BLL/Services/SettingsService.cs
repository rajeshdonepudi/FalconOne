using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DLL.Entities;
using FalconOne.DLL.Interfaces;
using System.Net;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class SettingsService : BaseService, ISettingsService
    {
        public SettingsService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ApiResponse> AddNewSetting(ApplicationSettingDTO model)
        {
            var setting = _mapper.Map<ApplicationSetting>(model);

            _unitOfWork.ApplicationSettingRepository.Add(setting);

            _unitOfWork.Save();

            return Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> DeletSetting(Guid id)
        {
            var setting = await _unitOfWork.ApplicationSettingRepository.FindAsync(x => x.Id == id);

            _unitOfWork.ApplicationSettingRepository.Delete(setting);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.NoContent, MessageHelper.SUCESSFULL));
        }
    }
}
