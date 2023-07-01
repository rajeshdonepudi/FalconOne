using FalconeOne.BLL.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse> LoginUserAsync(LoginRequestDto model);
        Task<ApiResponse> GetNewJWTByRefreshTokenAsync(string refreshToken);
        Task<ApiResponse> RevokeRefreshTokenAsync(string refreshToken);
        Task<ApiResponse> SignupNewUserAsync(SignupRequestDto model);
        Task<ApiResponse> ConfirmEmailAsync(ConfirmEmailRequestDto model);
        Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequestDto model);
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequestDto model);
        Task<ApiResponse> IsUserNameAvailable(string username);
    }
}
