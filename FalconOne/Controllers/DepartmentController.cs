using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FalconOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return ReturnResponse(await _departmentService.GetAllDepartments());
        }
    }
}
