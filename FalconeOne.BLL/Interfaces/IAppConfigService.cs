namespace FalconeOne.BLL.Interfaces
{
    public interface IAppConfigService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> GetValueAsync(string key);
    }
}
