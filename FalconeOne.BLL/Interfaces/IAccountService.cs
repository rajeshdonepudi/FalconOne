using FalconeOne.BLL.DTOs;
using FalconeOne.BLL.Helpers;

namespace FalconeOne.BLL.Interfaces
{
    /// <summary>
    /// Interface to fully manage user accounts.
    /// </summary>
    public interface IAccountService
    {
        Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequestDTO model);
        Task<AuthenticateResponseDTO> GetNewJWTByRefreshTokenAsync(string refreshToken);
        Task RevokeRefreshToken(string token);
        Task<ApiResponse> CreateNewUserAsync(RegisterNewUserRequestDTO model);
        Task<ApiResponse> VerifyEmailAsync(VerifyEmailDTO model);
        Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequestDTO model);
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequestDTO model);
        Task<IEnumerable<AccountDTO>> GetAllAsync();
        Task<ApiResponse> GetByIdAsync(string userId);
        Task<AuthenticateResponseDTO> UpdateUserAsync(int id, RegisterNewUserRequestDTO model);
        Task<ApiResponse> DeleteAsync(string userId);
    }
}
