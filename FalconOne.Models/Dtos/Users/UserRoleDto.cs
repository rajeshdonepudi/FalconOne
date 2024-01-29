using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Users
{
    public class UserRoleDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
