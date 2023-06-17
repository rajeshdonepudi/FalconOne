﻿using FalconeOne.BLL.Helpers;
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
        public DepartmentService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(userManager, unitOfWork, httpContextAccessor, configuration)
        {

        }

        public async Task<ApiResponse> GetAllDepartments()
        {
            Guid tenantId = await GetCurrentTenantId();

            IEnumerable<Department> departments = await _unitOfWork.DepartmentRepository.GetDepartmentsByTenantId(tenantId);

            List<DepartmentDTO> result = new();

            foreach (Department? department in departments)
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
