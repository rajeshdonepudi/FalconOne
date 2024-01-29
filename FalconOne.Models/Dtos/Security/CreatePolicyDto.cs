using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Security
{
    public class CreatePolicyDto
    {
        [Required]
        public string Name { get; set; }
    }
}
