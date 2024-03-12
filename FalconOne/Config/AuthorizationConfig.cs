using FalconOne.Security;
using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.Config
{
    public static class AuthorizationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                                           .RequireAuthenticatedUser()
                                           .RequireRole(SecurityRoles.GOD)
                                           .Build();

                options.AddPolicy(SecurityPolicies.GOD_POLICY, p =>
                {
                    p.RequireRole(SecurityRoles.GOD);
                });

                options.AddPolicy(SecurityPolicies.TENANT_USER_POLICY, p =>
                {
                    p.AllowedRoles(new List<string> { SecurityRoles.TENANT_USER });
                });

                options.AddPolicy(SecurityPolicies.TENANT_ADMIN_POLICY, p =>
                {
                    p.AllowedRoles(new List<string> { SecurityRoles.TENANT_ADMIN });
                });
            });
        }

        private static void AllowedRoles(this AuthorizationPolicyBuilder builder, List<string> roles)
        {
            var allowed = new List<string>
            {
                SecurityRoles.GOD
            };

            foreach (var role in roles)
            {
                allowed.Add(role);
            }

            builder.RequireRole(allowed.ToArray());
        }
    }
}
