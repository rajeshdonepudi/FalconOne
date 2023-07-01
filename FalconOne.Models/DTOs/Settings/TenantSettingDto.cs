namespace FalconOne.Models.DTOs.Settings
{
    public record TenantSettingDto
    {
        public string Key { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
        public string DisplayName { get; set; }
        public Guid Id { get; set; }
    }
}
