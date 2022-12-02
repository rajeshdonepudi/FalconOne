using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class ApplicationSettingDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
