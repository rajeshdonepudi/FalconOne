namespace FalconOne.Models.DTOs.Users
{
    public record UserInfoDto
    {
        public bool IsActive { get; set; }
        public string ResourceAlias { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
