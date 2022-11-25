using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class AuthenticateRequestDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
