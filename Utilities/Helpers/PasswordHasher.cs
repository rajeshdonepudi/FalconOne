using Microsoft.AspNetCore.Identity;

namespace Utilities.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(IdentityUser<Guid> user, string password)
        {
            return new PasswordHasher<IdentityUser<Guid>>().HashPassword(user, password);
        }
    }
}
