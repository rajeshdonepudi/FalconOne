using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace FalconeOne.BLL.Services
{
    public class PostService : BaseService, IPostService
    {
        public PostService(UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(userManager, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<ApiResponse> CreateAsync(NewPostDTO newPost)
        {
            var user = await _userManager.FindByIdAsync(newPost.PostedBy.ToString());

            var tenant = new Tenant();

            var department = new Department();

            if (newPost.TenantId != null && newPost.DepartmentId is null)
            {
                tenant = await _unitOfWork.TenantRepository.FindAsync(newPost.TenantId.GetValueOrDefault());
            }

            if (newPost.DepartmentId != null && newPost.TenantId is null)
            {
                department = await _unitOfWork.DepartmentRepository.FindAsync(newPost.DepartmentId.GetValueOrDefault());
            }

            await _unitOfWork.PostRepository.AddAsync(new Post
            {
                Content = newPost.Content,
                CreatedOn = DateTime.UtcNow,
                PostedOn = newPost.PostedOn,
                DepartmentId = department?.Id,
                TenantId = tenant?.Id,
                PostedBy = user
            });

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllPosts()
        {
            var posts = await _unitOfWork.PostRepository.GetAllAsync();

            var result = new List<PostDTO>();

            foreach (var post in posts)
            {
                result.Add(new PostDTO
                {
                    Content = post.Content,
                    DepartmentId = post.DepartmentId,
                    PostedBy = new UserDTO
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
