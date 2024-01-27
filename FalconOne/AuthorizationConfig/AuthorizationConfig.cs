using FalconeOne.BLL.Interfaces;
using FalconOne.Models.Entities;

namespace FalconOne.API.AuthorizationConfig
{
    public static class AuthorizationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                var appPolicyService = services.BuildServiceProvider().GetService<IAppPolicyService>();

                var policies = appPolicyService!.GetAllPolicies().Result;

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
            });
        }
    }
}
