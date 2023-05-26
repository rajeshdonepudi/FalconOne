using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class CreatePolicyDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
