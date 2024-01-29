using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public class SignupRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [Phone]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required.")]
        public required string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
        [DataType(DataType.Password, ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password should be same as password.")]
        public required string ConfirmPassword { get; set; }
    }
}
