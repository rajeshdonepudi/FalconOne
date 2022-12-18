using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using System.Net;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        public async Task<ApiResponse> GetAllDepartments()
        {
            var departments = await _unitOfWork.DepartmentRepository.GetAllAsync();

            var result = _mapper.Map<List<DepartmentDTO>>(departments);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
