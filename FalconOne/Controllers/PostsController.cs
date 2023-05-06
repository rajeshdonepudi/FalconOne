using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utilities.DTOs;

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
        public async Task<IActionResult> Get()
        {
            return ReturnResponse(await _postsService.GetAllPosts());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPostDTO postDTO)
        {
            var response = await _postsService.CreateAsync(postDTO);

            return ReturnResponse(response);
        }
    }
}
