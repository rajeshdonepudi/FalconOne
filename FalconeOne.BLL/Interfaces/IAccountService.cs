using FalconeOne.BLL.Helpers;
using Utilities.DTOs;

namespace FalconeOne.BLL.Interfaces
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
        Task<ApiResponse> GetAllAsync();
        Task<ApiResponse> GetByIdAsync(string userId);
        Task<AuthenticateResponseDTO> UpdateUserAsync(int id, RegisterNewUserRequestDTO model);
        Task<ApiResponse> DeleteAsync(string userId);
        Task<ApiResponse> AddUserToRoleAsync(AddToRoleDTO model);
    }
}
