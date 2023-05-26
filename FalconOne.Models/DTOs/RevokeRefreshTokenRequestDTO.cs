using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class RevokeRefreshTokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
