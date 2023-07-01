namespace FalconOne.Models.DTOs.Settings
{
    public record TenantSettingsResponse
    {
        public string SettingType { get; set; }
        public List<TenantSettingDto> Settings { get; set; }
    }
}
