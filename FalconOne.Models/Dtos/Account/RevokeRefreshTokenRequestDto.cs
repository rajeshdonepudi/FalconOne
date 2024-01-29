using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public class RevokeRefreshTokenRequestDto
    {
        [Required]
        public required string RefreshToken { get; set; }
    }
}
