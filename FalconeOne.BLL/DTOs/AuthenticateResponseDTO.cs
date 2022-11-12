using System.Text.Json.Serialization;

namespace FalconeOne.BLL.DTOs
{
    public class AuthenticateResponseDTO
    {
        public string JWTToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
