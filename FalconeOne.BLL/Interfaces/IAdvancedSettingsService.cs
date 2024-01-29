namespace FalconeOne.BLL.Interfaces
{
    public interface IAdvancedSettingsService
    {
        Task<string> HashPasswordAsync(string password);
    }
}
