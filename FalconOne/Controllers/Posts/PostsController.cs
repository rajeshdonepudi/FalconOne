using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.DTOs;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers.Posts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ResourceIdentifier(AppResourceCodes.Post.ADD_NEW_POST)]
        public async Task<IActionResult> AddNewPost(NewPostDto model)
        {
            var result = await _postService.CreateAsync(model);

            return ReturnResponse(result);
        }
    }
}
