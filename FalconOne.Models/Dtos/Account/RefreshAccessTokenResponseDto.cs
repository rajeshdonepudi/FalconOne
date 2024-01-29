namespace FalconOne.Models.DTOs.Account
{
    public record RefreshAccessTokenResponseDto
    {
        public required string JWTToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
