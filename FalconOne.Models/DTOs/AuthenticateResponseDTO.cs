namespace FalconOne.Models.DTOs
{
    public record AuthenticateResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JWTToken { get; set; }
        public Guid TenantId { get; set; }
        public string RefreshToken { get; set; }
        public string ProfilePicture  { get; set; }
    }
}
