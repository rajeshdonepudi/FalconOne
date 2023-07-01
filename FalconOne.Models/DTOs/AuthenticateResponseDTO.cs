namespace FalconOne.Models.DTOs
{
    public class AuthenticateResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JWTToken { get; set; }
        public List<Guid> Tenants { get; set; }
        public string RefreshToken { get; set; }
    }
}
