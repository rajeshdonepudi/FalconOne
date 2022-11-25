using AutoMapper;
using FalconeOne.BLL.Interfaces;
using FalconOne.DLL.Entities;
using FalconOne.DLL.Interfaces;
using Utilities.DTOs;

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
            _unitOfWork.RequestInformationRepository.Add(info);
            _unitOfWork.Save();
        }
    }
}
