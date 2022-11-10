using System.ComponentModel.DataAnnotations;

namespace FalconeOne.BLL.DTOs
{
    public class ResetPasswordRequestDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string ResetToken { get; set; }

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
