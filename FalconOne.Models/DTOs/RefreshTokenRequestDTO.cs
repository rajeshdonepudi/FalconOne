using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
