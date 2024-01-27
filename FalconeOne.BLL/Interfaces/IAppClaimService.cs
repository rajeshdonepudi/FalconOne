using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAppClaimService
    {
        Task<bool> AddClaimToRoleAsync(AddClaimToRoleDto model);
        Task<bool> AddClaimToUserAsync(AddClaimToUserDto model);
        Task<bool> AddClaimsToUserAsync(AddClaimsToUserDto model);
        Task<bool> CreateClaimAsync(UserClaimDto model);
        Task<IEnumerable<string>> GetAllClaimsAsync();
        Task<bool> DeleteClaimAsync(Guid guid);
    }
}
