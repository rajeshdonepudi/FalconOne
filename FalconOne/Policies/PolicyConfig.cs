using FalconeOne.BLL.Interfaces;
using FalconOne.DLL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.Policies
{
    public static class PolicyConfig
    {
        public static void Configure(AuthorizationOptions options, ServiceProvider provider)
        {
            using (var serviceScope = provider.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var appPolicyService = services.GetService<IAppPolicyService>();

                var policies = appPolicyService.GetAllPolicies().Result;

                foreach (var policy in (IEnumerable<ApplicationPolicy>)policies.Response)
                {
                    if (policy.PolicyClaims.Any())
                    {
                        options.AddPolicy(policy.Name, p =>
                        {
                            foreach (var claim in policy.PolicyClaims)
                            {
                                p.RequireClaim(claim.Type, claim.Name);
                            }
                        });
                    }
                }
            }
        }
    }
}
