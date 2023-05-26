using Microsoft.AspNetCore.Identity;

namespace FalconOne.Helpers.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(IdentityUser<Guid> user, string password)
        {
            return new PasswordHasher<IdentityUser<Guid>>().HashPassword(user, password);
        }
    }
}
