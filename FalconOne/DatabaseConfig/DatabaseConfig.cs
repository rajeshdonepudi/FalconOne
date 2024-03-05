using FalconOne.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.API.DatabaseConfig
{
    public static class PolicyConfig
    {
        public static void Configure(AuthorizationOptions options, ServiceProvider provider)
        {
            using (IServiceScope serviceScope = provider.CreateScope())
            {
                IServiceProvider services = serviceScope.ServiceProvider;

                IAppPolicyService? appPolicyService = services.GetService<IAppPolicyService>();

                var policies = appPolicyService!.GetAllPoliciesAsync().Result;

                foreach (SecurityPolicy applicationPolicy in policies)
                {
                    if (applicationPolicy.PolicyClaims.Any())
                    {
                        Console.WriteLine(applicationPolicy.Name);
                        foreach (SecurityClaim claim in applicationPolicy.PolicyClaims)
                        {
                            Console.WriteLine(claim.Type + "" + claim.Value);
                        }
                    }
                }

                if (policies is not null)
                {
                    foreach (SecurityPolicy applicationPolicy in policies)
                    {
                        if (applicationPolicy.PolicyClaims.Any())
                        {
                            options.AddPolicy(applicationPolicy.Name, p =>
                            {
                                foreach (SecurityClaim claim in applicationPolicy.PolicyClaims)
                                {
                                    Console.WriteLine(claim.Type + "00000000" + claim.Value);
                                    p.RequireClaim(claim.Type, new string[] { claim.Value });
                                }
                            });
                        }
                    }
                }
            }
        }
    }
    public static class DatabaseConfig
    {
        public static void Configure(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                FalconOneContext? context = scope.ServiceProvider.GetService<FalconOneContext>();

                if (context is not null)
                {
                    bool hasPendingMigrations = context.Database.GetPendingMigrations().Any();

                    if (hasPendingMigrations)
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
