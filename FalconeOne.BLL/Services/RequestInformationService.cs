using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class RequestInformationService : IRequestInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SaveRequestInfoAsync(RequestInformationDTO model)
        {
            var requestInformation = new RequestInformation
            {
                Method = model.Method,
                Scheme = model.Scheme,
                Action = model.Action,
                Controller = model.Controller,
                CreatedOn = DateTime.UtcNow,
                Host = model.Host,
                Protocol = model.Protocol,
                Port = model.Port,
                TraceIdentifier = model.TraceIdentifier,
                ResourceCode = model.ResourceCode,
                UserAgent = model.UserAgent,
                Path = model.Path
            };

            await _unitOfWork.RequestInformationRepository.AddAsync(requestInformation);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ApiResponse> GetAllAsync(PageParams pageParams)
        {
            var res = await _unitOfWork.RequestInformationRepository.GetAllAsync(pageParams);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, res));
        }
    }
}
