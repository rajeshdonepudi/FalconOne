using System.ComponentModel.DataAnnotations;

namespace FalconeOne.BLL.DTOs
{
    public class ValidateResetTokenRequestDTO
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
