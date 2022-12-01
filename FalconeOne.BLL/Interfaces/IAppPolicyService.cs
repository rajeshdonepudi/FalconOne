using FalconeOne.BLL.Helpers;
using Utilities.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppPolicyService
    {
        Task<ApiResponse> CreatePolicy(CreatePolicyDTO model);
        Task<ApiResponse> GetAllPolicies();
    }
}
