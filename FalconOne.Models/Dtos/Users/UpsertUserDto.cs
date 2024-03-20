using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Users
{
    public record UpsertUserDto
    {
        public string? ResourceAlias { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public required string Email { get; set; }
        public string? Phone { get; set; }
        //[Required(ErrorMessage = "Password is required.")]
        [MinLength(8)]
        public string? Password { get; set; }
        [MinLength(8)]
        //[Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm password should match.")]
        public string? ConfirmPassword { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneConfirmed { get; set; } = false;
        public bool LockoutEnabled { get; set; } = false;
        public bool TwoFactorEnabled { get; set; } = false;
        public bool IsActive { get; set; } = false;

    }
}
