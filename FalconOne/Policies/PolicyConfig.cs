using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.Policies
{
    public static class PolicyConfig
    {
        public static void Configure(AuthorizationOptions options)
        {
            options.AddPolicy("string", policy =>
            {
                policy.RequireClaim("string");
            });
        }
    }
}
