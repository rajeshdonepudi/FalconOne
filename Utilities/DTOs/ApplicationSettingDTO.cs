using System.ComponentModel.DataAnnotations;
using Utilities.Enumerations;

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
        public SettingTypeEnum SettingType { get; set; }
    }
}
