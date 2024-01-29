using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public record ForgotPasswordRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
