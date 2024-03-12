using FalconOne.API.Config;
using FalconOne.API.Filters;
using FalconOne.DAL;
using IdenticonSharp.Identicons;
using IdenticonSharp.Identicons.Defaults.GitHub;
using KE.IdenticonSharp.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.API
{
    public static class FalconOneConfiguration
    {
        private static void RegisterBaseServies(WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddIdenticonSharp<GitHubIdenticonProvider, GitHubIdenticonOptions>(options =>
            {
                options.SpriteSize = 10;
                options.Size = 256;
                options.HashAlgorithm = HashProvider.SHA512;
            });

            builder.Services.AddHealthChecks();

            builder.Services.AddControllers(c =>
            {
                c.Filters.Add(new AsyncActionFilter());
                c.Filters.Add<ApiExceptionFilterAttribute>();
            });

            builder.Services.AddHttpClient();

            builder.Services.AddDbContext<FalconOneContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        }
        public static void Register(WebApplicationBuilder builder)
        {
            RegisterBaseServies(builder);

            DependencyConfig.Configure(builder);

            AuthenticationConfig.Configure(builder);

            SwaggerConfig.Configure(builder);

            AuthorizationConfig.Configure(builder.Services);

            CacheConfig.Configure(builder);

            CORSConfig.Configure(builder);

            RateLimiterConfig.Configure(builder);
        }

        public static void Bootstrap(IServiceProvider serviceProvider)
        {
            DatabaseConfig.Configure(serviceProvider);
        }

        public static void Seed(IServiceProvider serviceProvider)
        {
            DbSeeder.Seed(serviceProvider);
        }
    }
}
