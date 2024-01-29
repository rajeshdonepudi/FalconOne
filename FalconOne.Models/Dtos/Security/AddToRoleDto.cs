using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Security
{
    public record AddToRoleDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
