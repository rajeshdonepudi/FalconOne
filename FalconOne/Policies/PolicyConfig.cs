using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.Policies
{
    public static class PolicyConfig
    {
        public static void Configure(AuthorizationOptions authorizationOptions, ServiceProvider provider)
        {
            using (var serviceScope = provider.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var appPolicyService = services.GetService<IAppPolicyService>();

                var policies = appPolicyService!.GetAllPolicies().Result;

                foreach (var applicationPolicy in policies.Response as IEnumerable<ApplicationPolicy>)
                {
                    if (applicationPolicy.PolicyClaims.Any())
                    {
                        Console.WriteLine(applicationPolicy.Name);
                        foreach (var claim in applicationPolicy.PolicyClaims)
                        {
                            Console.WriteLine(claim.Type + "" + claim.Value);
                        }
                    }
                }

                if (policies is not null)
                {
                    foreach (var applicationPolicy in policies.Response as IEnumerable<ApplicationPolicy>)
                    {
                        if (applicationPolicy.PolicyClaims.Any())
                        {
                            authorizationOptions.AddPolicy(applicationPolicy.Name, p =>
                            {
                                foreach (var claim in applicationPolicy.PolicyClaims)
                                {
                                    p.RequireClaim(claim.Type, claim.Value.Split(','));
                                }
                            });
                        }
                    }
                }
            }
        }
    }
}
