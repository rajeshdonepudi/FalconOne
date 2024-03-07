using FalconeOne.BLL.Interfaces;
using FalconeOne.BLL.Services;
using FalconOne.API.Filters;
using FalconOne.DAL;
using FalconOne.DAL.Contracts;
using FalconOne.Models.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FalconOne.API.DependencyConfig
{
    public static class DependencyConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ISystemLogsService, SystemLogsService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<AsyncActionFilter>();
            builder.Services.AddTransient<ITokenService, TokenService>();
            builder.Services.AddTransient<IAppConfigService, AppConfigService>();
            builder.Services.AddScoped<ITenantProvider, TenantProvider>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ISecurityService, SecurityService>();
            builder.Services.AddTransient<IAdvancedSettingsService, AdvancedSettingsService>();
            builder.Services.AddTransient<IPasswordHasher<object>, PasswordHasher<object>>();
        }
    }
}
