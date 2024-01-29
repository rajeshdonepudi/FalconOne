namespace FalconOne.Models.DTOs.Users
{
    public record UserInfoDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
