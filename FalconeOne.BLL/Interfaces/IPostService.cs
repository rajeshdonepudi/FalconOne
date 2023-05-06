using FalconeOne.BLL.Helpers;
using Utilities.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IPostService
    {
        Task<ApiResponse> CreateAsync(NewPostDTO newPost);
        Task<ApiResponse> GetAllPosts();
    }
}
