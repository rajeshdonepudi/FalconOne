using FalconeOne.BLL.Interfaces;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.Policies
{
    public static class PolicyConfig
    {
        public static void Configure(AuthorizationOptions authorizationOptions, ServiceProvider provider)
        {
            using (IServiceScope serviceScope = provider.CreateScope())
            {
                IServiceProvider services = serviceScope.ServiceProvider;

                IAppPolicyService? appPolicyService = services.GetService<IAppPolicyService>();

                FalconeOne.BLL.Helpers.ApiResponse? policies = appPolicyService!.GetAllPolicies().Result;

                foreach (SecurityPolicy applicationPolicy in policies.Response as IEnumerable<SecurityPolicy>)
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
                    foreach (SecurityPolicy applicationPolicy in policies.Response as IEnumerable<SecurityPolicy>)
                    {
                        if (applicationPolicy.PolicyClaims.Any())
                        {
                            authorizationOptions.AddPolicy(applicationPolicy.Name, p =>
                            {
                                foreach (SecurityClaim claim in applicationPolicy.PolicyClaims)
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
