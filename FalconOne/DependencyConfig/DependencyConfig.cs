using FalconeOne.BLL.Interfaces;
using FalconeOne.BLL.Services;
using FalconOne.DLL;
using FalconOne.DLL.Interfaces;

namespace FalconOne.API.DependencyConfig
{
    public static class DependencyConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IRequestInformationService, RequestInformationService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAppRoleService, AppRoleService>();
            builder.Services.AddScoped<AsyncActionFilter>();
            builder.Services.AddTransient<ITokenService, TokenService>();
            builder.Services.AddTransient<IAppConfigService, AppConfigService>();
            builder.Services.AddTransient<IAppClaimService, AppClaimService>();
            builder.Services.AddTransient<IAppPolicyService, AppPolicyService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();
        }
    }
}
