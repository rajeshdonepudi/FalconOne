using System.Text.Json.Serialization;

namespace FalconeOne.BLL.DTOs
{
    public class AuthenticateResponseDTO
    {
        public string JWTToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
