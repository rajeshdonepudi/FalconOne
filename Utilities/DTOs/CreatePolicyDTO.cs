using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class CreatePolicyDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
