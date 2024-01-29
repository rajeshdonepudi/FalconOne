namespace FalconOne.Models.DTOs.Account
{
    public record ConfirmEmailRequestDto
    {
        public required string UserId { get; set; }
        public required string EmailConfirmationToken { get; set; }
    }
}
