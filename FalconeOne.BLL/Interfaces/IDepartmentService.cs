using FalconeOne.BLL.Helpers;

namespace FalconeOne.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<ApiResponse> GetAllDepartments();
    }
}
