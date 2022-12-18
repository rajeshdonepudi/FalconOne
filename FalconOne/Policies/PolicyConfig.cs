using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Entities;
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

                //var context = serviceScope.ServiceProvider.GetService<FalconOneContext>();

                //// auto migration
                //context.Database.Migrate();

                var appPolicyService = services.GetService<IAppPolicyService>();

                var policies = appPolicyService.GetAllPolicies().Result;

                foreach (var policy in policies.Response as IEnumerable<ApplicationPolicy>)
                {
                    if (policy.PolicyClaims.Any())
                    {
                        options.AddPolicy(policy.Name, p =>
                        {
                            foreach (var claim in policy.PolicyClaims)
                            {
                                p.RequireClaim(claim.Type, claim.Values.Split(','));
                            }
                        });
                    }
                }
            }
        }
    }
}
