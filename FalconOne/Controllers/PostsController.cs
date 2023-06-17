using FalconeOne.BLL.Interfaces;
using FalconOne.API.Attributes;
using FalconOne.Models.DTOs;
using FalconOne.ResourceCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly IPostService _postsService;

        public PostsController(IPostService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        [AllowAnonymous]
        [UserAction(AppResourceCodes.Account.REGISTER_NEW_USER)]

        public async Task<IActionResult> Get()
        {
            return ReturnResponse(await _postsService.GetAllPosts());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPostDTO postDTO)
        {
            FalconeOne.BLL.Helpers.ApiResponse response = await _postsService.CreateAsync(postDTO);

            return ReturnResponse(response);
        }
    }
}
