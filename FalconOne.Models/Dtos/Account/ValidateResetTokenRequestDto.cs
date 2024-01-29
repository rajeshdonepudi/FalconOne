using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public class ValidateResetTokenRequestDto
    {
        [Required]
        public required string UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Reset token is required.")]
        public required string ResetToken { get; set; }
        [Required]
        public required string NewPassword { get; set; }
        [Required]
        public required string ConfirmNewPassword { get; set; }
    }
}
