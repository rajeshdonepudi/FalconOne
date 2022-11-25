using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class ForgotPasswordRequestDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
