using FalconeOne.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FalconeOne.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAppConfigService _appConfigService;

        public TokenService(IAppConfigService appConfigService)
        {
            _appConfigService = appConfigService;
        }

        public async Task<string> GenerateJWTToken<T, T1>(T type, T1 claims)
        {
            string secret = await _appConfigService.GetValueAsync("JWT:Secret");

            JwtSecurityTokenHandler tokenHandler = new();

            byte[] key = Encoding.ASCII.GetBytes(secret);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Audience = await _appConfigService.GetValueAsync("JWT:Audience"),
                Issuer = await _appConfigService.GetValueAsync("JWT:Issuer"),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(await _appConfigService.GetValueAsync("JWT:ExpiresInMinutes"))),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            if (claims != null && claims is IEnumerable<Claim>)
            {
                tokenDescriptor.Subject = new ClaimsIdentity((IEnumerable<Claim>)claims);
            }

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
