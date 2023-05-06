using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork) : base(userManager, mapper, unitOfWork)
        {

        }

        public async Task<ApiResponse> GetAllDepartments()
        {
            var tenantId = await GetCurrentTenantId();

            var departments = await _unitOfWork.DepartmentRepository.GetQueryable().Where(x => x.TenantId == tenantId).ToListAsync();

            var result = _mapper.Map<List<DepartmentDTO>>(departments);

            result.Add(new DepartmentDTO
            {
                Id = tenantId,
                Name = "ORGANIZATION"
            });

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
