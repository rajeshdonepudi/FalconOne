using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public class ResetPasswordRequestDto
    {
        [Required]
        public required string UserId { get; set; }
        [Required]
        public required string ResetToken { get; set; }

        [Required]
        [MinLength(6)]
        public required string NewPassword { get; set; }

        [Required]
        [Compare("Password")]
        public required string ConfirmNewPassword { get; set; }
    }
}
