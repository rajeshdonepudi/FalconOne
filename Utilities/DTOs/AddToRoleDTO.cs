using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class AddToRoleDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
