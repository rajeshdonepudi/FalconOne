using FalconOne.API.Policies;

namespace FalconOne.API.AuthorizationConfig
{
    public static class AuthorizationConfig
    {
        public static void Configure(WebApplicationBuilder builder, ServiceProvider serviceScope)
        {
            builder.Services.AddAuthorization(options =>
            {
                PolicyConfig.Configure(options, serviceScope);
            });
        }
    }
}
