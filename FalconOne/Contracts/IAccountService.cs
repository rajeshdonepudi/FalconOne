using FalconeOne.BLL.Helpers;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;

namespace FalconOne.API.Contracts
{
    /// <summary>
    /// Interface to fully manage user accounts.
    /// </summary>
    public interface IAccountService
    {
        Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequestDTO model);
        Task<ApiResponse> GetNewJWTByRefreshTokenAsync(string refreshToken);
        Task<ApiResponse> RevokeRefreshTokenAsync(string refreshToken);
        Task<ApiResponse> CreateNewUserAsync(RegisterNewUserRequestDTO model);
        Task<ApiResponse> VerifyEmailAsync(VerifyEmailDTO model);
        Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequestDTO model);
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequestDTO model);
        Task<ApiResponse> GetAllAsync(PageParams model);
        Task<ApiResponse> GetByIdAsync(string userId);
        Task<AuthenticateResponseDTO> UpdateUserAsync(int id, RegisterNewUserRequestDTO model);
        Task<ApiResponse> DeleteAsync(string userId);
        Task<ApiResponse> AddUserToRoleAsync(AddToRoleDTO model);
        Task<ApiResponse> UpdateEmailConfirmed(string userId, bool value);
    }
}
