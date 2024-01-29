using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public required string RefreshToken { get; set; }
    }
}
