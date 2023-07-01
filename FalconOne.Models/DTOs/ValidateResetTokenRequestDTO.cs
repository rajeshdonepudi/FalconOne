using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class ValidateResetTokenRequestDto
    {
        [Required]
        public string UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Reset token is required.")]
        public string ResetToken { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
