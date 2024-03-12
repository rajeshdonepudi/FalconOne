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
        private readonly List<string> _policies = new() { "GOD" };

        public FalconOneAuthorizeAttribute(string[] policies)
        {
            _policies = policies.ToList();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));

            var tenantService = context.HttpContext.RequestServices.GetService<ITenantProvider>();
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

            if (tenantService is null || configuration is null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var currentTenantId = await tenantService.GetTenantId();

            string bearerToken = context?.HttpContext?.Request?.Headers["Authorization"].FirstOrDefault()!;

            if (string.IsNullOrEmpty(bearerToken) || !bearerToken.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedResult();

                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = configuration["JWT:Secret"];
            var issuer = configuration["JWT:Issuer"];

            var validationParameters = new TokenValidationParameters()
            {
                ValidIssuer = issuer,
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(secretKey!)),
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };

            string token = bearerToken.Substring(7);

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);

                var tenantIdClaim = claimsPrincipal.FindFirst("tenantId");

                if (tenantIdClaim == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                Guid tokenTenantId;

                Guid.TryParse(tenantIdClaim.Value, out tokenTenantId);

                if (currentTenantId != tokenTenantId)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                string tenantId = tenantIdClaim.Value;

                var authService = context!.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();

                var authorizationResults = new List<AuthorizationResult>();

                foreach (string policy in _policies)
                {
                    AuthorizationResult authorizationResult = await authService.AuthorizeAsync(claimsPrincipal, null, policy);

                    authorizationResults.Add(authorizationResult);
                }

                if (authorizationResults.Any(result => !result.Succeeded))
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
