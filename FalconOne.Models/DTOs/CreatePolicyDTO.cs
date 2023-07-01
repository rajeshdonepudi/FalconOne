using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class CreatePolicyDto
    {
        [Required]
        public string Name { get; set; }
    }
}
