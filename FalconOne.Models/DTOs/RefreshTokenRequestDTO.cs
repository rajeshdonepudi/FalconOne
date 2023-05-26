using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class RefreshTokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
