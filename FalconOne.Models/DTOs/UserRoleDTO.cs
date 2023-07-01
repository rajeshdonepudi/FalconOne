using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class UserRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
