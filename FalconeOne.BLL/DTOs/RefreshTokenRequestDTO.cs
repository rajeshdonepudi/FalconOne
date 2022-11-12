using System.ComponentModel.DataAnnotations;

namespace FalconeOne.BLL.DTOs
{
    public class RefreshTokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
