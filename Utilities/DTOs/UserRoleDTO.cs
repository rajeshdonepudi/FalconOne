using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class UserRoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
