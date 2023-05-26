using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddToRoleDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
