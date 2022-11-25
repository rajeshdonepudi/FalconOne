using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class RevokeRefreshTokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
