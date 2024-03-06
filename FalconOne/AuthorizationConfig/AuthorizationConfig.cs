using FalconOne.Security;

namespace FalconOne.API.AuthorizationConfig
{
    public static class AuthorizationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(SecurityPolicies.GOD_POLICY, p =>
                {
                    p.RequireRole(SecurityRoles.GOD);
                });

                options.AddPolicy(SecurityPolicies.TENANT_USER_POLICY, p =>
                {
                    p.RequireRole(SecurityRoles.TENANT_USER);
                });

                options.AddPolicy(SecurityPolicies.TENANT_ADMIN_POLICY, p =>
                {
                    p.RequireRole(SecurityRoles.TENANT_ADMIN);
                });
            });
        }
    }
}
