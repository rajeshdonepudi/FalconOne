using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppPolicyService
    {
        Task<bool> CreatePolicy(CreatePolicyDto model);
        Task<IEnumerable<SecurityPolicy>> GetAllPolicies();
        Task<bool> DeletePolicy(Guid id);
    }
}
