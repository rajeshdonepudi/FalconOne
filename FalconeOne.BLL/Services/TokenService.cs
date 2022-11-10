using FalconeOne.BLL.Interfaces;
using FalconOne.DLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FalconeOne.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAppConfigService _appConfigService;
        private readonly UserManager<User> _userManager;

        public TokenService(IAppConfigService appConfigService, UserManager<User> userManager)
        {
            _appConfigService = appConfigService;
            _userManager = userManager;
        }

        public async Task<string> GenerateJWTToken<T, T1>(T type, T1 claims)
        {
            var secret = await _appConfigService.GetValue("JWT:Secret");
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            if (claims != null && claims is IEnumerable<Claim>)
            {
                tokenDescriptor.Subject = new ClaimsIdentity((IEnumerable<Claim>) claims);
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
