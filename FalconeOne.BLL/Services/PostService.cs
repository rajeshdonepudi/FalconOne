using AutoMapper;
using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class PostService : BaseService, IPostService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(UserManager<User> userManager,
           IMapper mapper,
           IUnitOfWork unitOfWork) : base(userManager, mapper, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<ApiResponse> CreateAsync(NewPostDTO newPost)
        {
            var user = await _userManager.FindByIdAsync(newPost.PostedBy.ToString());

            Tenant tenant = null;
            Department department = null;

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
                Department = department,
                Tenant = tenant,
                PostedBy = user
            });

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new ApiResponse(HttpStatusCode.Created, MessageHelper.SUCESSFULL));
        }

        public async Task<ApiResponse> GetAllPosts()
        {
            var entitites = await _unitOfWork.PostRepository.GetAllAsync();

            var result = _mapper.Map<List<PostDTO>>(entitites);

            return await Task.FromResult(new ApiResponse(HttpStatusCode.OK, MessageHelper.SUCESSFULL, result));
        }
    }
}
