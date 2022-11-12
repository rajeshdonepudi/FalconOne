using System.ComponentModel.DataAnnotations;

namespace FalconeOne.BLL.DTOs
{
    public class RevokeRefreshTokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
