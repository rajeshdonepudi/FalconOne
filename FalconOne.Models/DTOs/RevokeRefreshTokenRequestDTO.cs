using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class RevokeRefreshTokenRequestDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
