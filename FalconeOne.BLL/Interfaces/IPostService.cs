using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IPostService
    {
        Task<ApiResponse> CreateAsync(NewPostDTO newPost);
        Task<ApiResponse> GetAllPosts();
    }
}
