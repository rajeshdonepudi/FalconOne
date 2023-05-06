using FalconeOne.BLL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class AppConfigService : IAppConfigService
    {
        private readonly IConfiguration _configuration;
        public AppConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get value of the key accepts section name with key or only key ex. {Section:Key | key}
        /// </summary>
        /// <param name="key"></param>
        /// <returns>string</returns>
        public Task<string> GetValue(string key)
        {
            return Task.FromResult(_configuration[key]);
        }
    }
}
