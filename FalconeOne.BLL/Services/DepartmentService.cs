using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(userManager, unitOfWork, httpContextAccessor)
        {

        }

        public async Task<ApiResponse> GetAllDepartments()
        {
            var tenantId = await GetCurrentTenantId();

            var departments = await _unitOfWork.DepartmentRepository.GetQueryable().Where(x => x.TenantId == tenantId).ToListAsync();

            var result = new List<DepartmentDTO>();

            foreach (var department in departments)
            {
                result.Add(new DepartmentDTO
                {
                    Name = department.Name,
                    Id = department.Id
                });
            }

            result.Add(new DepartmentDTO
            {
                Id = tenantId,
                Name = "ORGANIZATION"
            });

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
