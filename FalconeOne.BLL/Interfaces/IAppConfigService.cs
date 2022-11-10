namespace FalconeOne.BLL.Interfaces
{
    public interface IAppConfigService
    {
        Task<string> GetValue(string key);
    }
}
