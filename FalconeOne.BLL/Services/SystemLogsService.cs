using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using System.Net;
using System.Threading;

namespace FalconeOne.BLL.Services
{
    public class SystemLogsService : ISystemLogsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemLogsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SaveRequestInfoAsync(RequestInformationDto model)
        {
            SystemLog requestInformation = new()
            {
                Method = model.Method,
                Scheme = model.Scheme,
                IP = model.IP,
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

            await _unitOfWork.RequestInformationRepository.AddAsync(requestInformation, CancellationToken.None);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<ApiResponse> GetAllAsync(PageParams pageParams)
        {
            PagedList<SystemLog> res = await _unitOfWork.RequestInformationRepository.GetAllRequestInfoPaginatedAsync(pageParams, CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, res));
        }
    }
}
