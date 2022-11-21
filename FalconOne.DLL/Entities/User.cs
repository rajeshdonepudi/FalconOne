using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FalconOne.DLL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User()
        {
            RefreshTokens = new List<RefreshToken>();
        }

        public List<RefreshToken> RefreshTokens { get; set; }

        public bool OwnsToken(string token)
        {
            return RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
