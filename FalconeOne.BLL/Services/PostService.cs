using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class PostService : BaseService, IPostService
    {
        public PostService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITenantService tenantService)

            : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
        }

        public async Task<ApiResponse> CreateAsync(NewPostDto model)
        {
            if(model is null || model.PostedBy == Guid.Empty)
            {
                throw new AppException(MessageHelper.INVALID_REQUEST);
            }

            User? user = await _userManager.FindByIdAsync(Convert.ToString(model.PostedBy) ?? string.Empty);

            if(user is null)
            {
                throw new AppException(MessageHelper.INVALID_REQUEST);
            }

            Tenant tenant = new();

            Department department = new();

            if (model.TenantId != null && model.DepartmentId is null)
            {
                tenant = await _unitOfWork.TenantRepository.GetByIdAsync(model.TenantId.GetValueOrDefault(), CancellationToken.None);
            }

            if (model.DepartmentId != null && model.TenantId is null)
            {
                department = await _unitOfWork.DepartmentRepository.GetByIdAsync(model.DepartmentId.GetValueOrDefault(), CancellationToken.None);
            }

            await _unitOfWork.PostRepository.AddAsync(new Post
            {
                Content = model.Content ?? string.Empty,
                CreatedOn = DateTime.UtcNow,
                PostedOn = model.PostedOn,
                DepartmentId = department?.Id,
                TenantId = tenant?.Id,
                PostedBy = (Employee) user
            }, CancellationToken.None);

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllPosts()
        {
            IEnumerable<Post> posts = await _unitOfWork.PostRepository.GetAllAsync(CancellationToken.None);

            List<PostDto> result = new();

            foreach (Post post in posts)
            {
                result.Add(new PostDto
                {
                    Content = post.Content,
                    DepartmentId = post.DepartmentId,
                    PostedBy = new UserDto
                    {
                        FirstName = post.PostedBy.FirstName,
                        LastName = post.PostedBy.LastName,
                        Id = post.PostedBy.Id
                    },
                    PostedOn = post.PostedOn,
                    TenantId = post.TenantId
                });
            }

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
