using FalconOne.API.Policies;
using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.AuthorizationConfig
{
    public static class AuthorizationConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                PolicyConfig.Configure(options);
            });
        }
    }
}
