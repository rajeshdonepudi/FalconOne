using FalconOne.Models.DTOs.Account;

namespace FalconeOne.BLL.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<LoginResponseDto> LoginAsync(LoginRequestDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<RegisterResponse> RegisterAsync(SignupRequestDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<RefreshAccessTokenResponseDto> GetJWTByRefreshTokenAsync(string refreshToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<bool> RevokeRefreshTokenAsync(string refreshToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> ConfirmEmailAsync(ConfirmEmailRequestDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SendForgotPasswordResetTokenAsync(ForgotPasswordRequestDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> ResetPasswordAsync(ResetPasswordRequestDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> IsUserNameAvailable(string username);
    }
}
