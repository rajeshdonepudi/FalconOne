using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FalconeOne.BLL.Services
{
    public class AdvancedSettingsService : BaseService, IAdvancedSettingsService
    {
        private readonly IPasswordHasher<object> _passwordHasher;

        public AdvancedSettingsService(UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            ITenantProvider tenantService,
            IPasswordHasher<object> passwordHasher) : base(userManager, unitOfWork, httpContextAccessor, configuration, tenantService)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task<string> HashPasswordAsync(string password)
        {
            var hashedPassword = await Task.FromResult(_passwordHasher.HashPassword(new object(), password));

            return hashedPassword;
        }
    }
}
