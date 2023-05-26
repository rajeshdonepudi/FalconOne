using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class UserRoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
