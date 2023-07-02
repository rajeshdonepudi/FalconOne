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
        private readonly string _policy;

        public FalconOneAuthorizeAttribute(string policy)
        {
            _policy = policy;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var tenantService = context.HttpContext.RequestServices.GetService<ITenantService>();

            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

            var currentTenantId = tenantService.GetTenantId().Result;

            string bearerToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(bearerToken) || !bearerToken.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenValidationParameters = new TokenValidationParameters
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
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

                var tenantIdClaim = claimsPrincipal.FindFirst("tenantId");

                Guid tokenTenantId;

                Guid.TryParse(tenantIdClaim.Value, out tokenTenantId);

                if (tenantIdClaim == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                if(currentTenantId != tokenTenantId)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                string tenantId = tenantIdClaim.Value;

                var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();

                var authorizationResult = await authService.AuthorizeAsync(claimsPrincipal, null, _policy);

                if (!authorizationResult.Succeeded)
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
