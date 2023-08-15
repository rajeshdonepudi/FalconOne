using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Users
{
    public record AddUserDto
    {
        public AddUserDto()
        {
            Tenants = new List<Guid>();
            Permissions = new List<Guid>();
            Roles = new List<Guid>();
        }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8)]
        public string Password { get; set; }
        [MinLength(8)]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm password should match.")]
        public string ConfirmPassword { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsPhoneConfirmed { get; set; } = false;
        public bool IsLockoutEnabled { get; set; } = false;
        public bool IsTwoFactorEnabled { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public List<Guid>? Roles { get; set; }
        public List<Guid>? Permissions { get; set; }
        public List<Guid>? Tenants { get; set; }
    }
}
