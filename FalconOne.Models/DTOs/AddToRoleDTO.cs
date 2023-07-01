using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddToRoleDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
