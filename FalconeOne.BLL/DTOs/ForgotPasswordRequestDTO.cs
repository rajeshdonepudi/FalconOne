using System.ComponentModel.DataAnnotations;

namespace FalconeOne.BLL.DTOs
{
    public class ForgotPasswordRequestDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
