using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class ForgotPasswordRequestDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
