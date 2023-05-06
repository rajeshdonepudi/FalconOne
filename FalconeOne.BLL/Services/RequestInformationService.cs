using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using System.Net;
using Utilities.DTOs;
using Utilities.Helpers;

namespace FalconeOne.BLL.Services
{
    public class RequestInformationService : IRequestInformationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RequestInformationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveRequestInfoAsync(RequestInformationDTO model)
        {
            var info = _mapper.Map<RequestInformation>(model);

            await _unitOfWork.RequestInformationRepository.AddAsync(info);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ApiResponse> GetAllAsync(PageParams pageParams)
        {
            var res = await _unitOfWork.RequestInformationRepository.GetAllAsync(pageParams);

            //res = res.OrderBy(x => x.RecordedOn);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, res));
        }
    }
}
