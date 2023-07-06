using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            ITenantService tenantService) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {

        }

        public async Task<ApiResponse> GetAllDepartments()
        {
            Guid tenantId = await GetCurrentTenantId();

            IEnumerable<Department> departments = await _unitOfWork.DepartmentRepository.GetDepartmentsByTenantId(tenantId, CancellationToken.None);

            List<DepartmentDto> result = new();

            foreach (Department? department in departments)
            {
                result.Add(new DepartmentDto(department));
            }

            result.Add(new DepartmentDto
            {
                Id = tenantId,
                Name = "ORGANIZATION"
            });

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
