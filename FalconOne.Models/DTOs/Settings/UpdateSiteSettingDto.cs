using FalconOne.Enumerations.Settings;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Settings
{
    public record UpdateSiteSettingDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public SystemSettingTypeEnum SettingType { get; set; }
    }
}
