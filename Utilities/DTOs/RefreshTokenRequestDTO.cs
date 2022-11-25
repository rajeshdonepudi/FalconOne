using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class RefreshTokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
