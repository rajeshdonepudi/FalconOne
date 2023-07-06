using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FalconOne.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FalconOneAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly List<string> _policies = new() { "FalconOneSuperAdmin" };

        public FalconOneAuthorizeAttribute(string[] policies)
        {
            _policies = policies.ToList();
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            ITenantService? tenantService = context.HttpContext.RequestServices.GetService<ITenantService>();

            IConfiguration? configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

            Guid currentTenantId = tenantService.GetTenantId().Result;

            string bearerToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(bearerToken) || !bearerToken.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            JwtSecurityTokenHandler tokenHandler = new();

            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = false,
                ClockSkew = TimeSpan.Zero
            };

            string token = bearerToken.Substring(7);

            try
            {
                System.Security.Claims.ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

                System.Security.Claims.Claim? tenantIdClaim = claimsPrincipal.FindFirst("tenantId");

                Guid tokenTenantId;

                Guid.TryParse(tenantIdClaim.Value, out tokenTenantId);

                if (tenantIdClaim == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                if (currentTenantId != tokenTenantId)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                string tenantId = tenantIdClaim.Value;

                IAuthorizationService authService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();

                List<AuthorizationResult> authorizationResults = new();

                foreach (string policy in _policies)
                {
                    AuthorizationResult authorizationResult = await authService.AuthorizeAsync(claimsPrincipal, null, policy);
                    authorizationResults.Add(authorizationResult);
                }

                if (!authorizationResults.Any(result => result.Succeeded))
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
