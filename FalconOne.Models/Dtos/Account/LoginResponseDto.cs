namespace FalconOne.Models.DTOs.Account
{
    public record LoginResponseDto
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string AccessToken { get; set; }
        public required Guid TenantId { get; set; }
        public required string RefreshToken { get; set; }
        public required string ProfilePicture { get; set; }
    }
}
