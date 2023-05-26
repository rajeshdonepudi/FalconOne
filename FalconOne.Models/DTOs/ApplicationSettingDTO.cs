using FalconOne.Enumerations.Settings;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class ApplicationSettingDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public string? Description { get; set; }
        public SettingTypeEnum SettingType { get; set; }
    }
}
