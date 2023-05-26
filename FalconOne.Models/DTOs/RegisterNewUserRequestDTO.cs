using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class RegisterNewUserRequestDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Phone]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [DataType(DataType.Password, ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password should be same as password.")]
        public string ConfirmPassword { get; set; }
    }
}
