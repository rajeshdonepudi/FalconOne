using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppPolicyService
    {
        Task<ApiResponse> CreatePolicy(CreatePolicyDTO model);
        Task<ApiResponse> GetAllPolicies();
        Task<ApiResponse> DeletePolicy(Guid id);
    }
}
