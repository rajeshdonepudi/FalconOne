using System.Text.Json.Serialization;

namespace Utilities.DTOs
{
    public class AuthenticateResponseDTO
    {
        public string JWTToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
