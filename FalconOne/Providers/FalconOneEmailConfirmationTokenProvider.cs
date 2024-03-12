using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FalconOne.API.Providers
{
    public class FalconOneEmailConfirmationTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        private readonly ILogger logger;

        public FalconOneEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider,
                                        IOptions<FalconOneEmailConfirmationTokenProviderOptions> options, ILogger<FalconOneEmailConfirmationTokenProvider<TUser>> logger)
            : base(dataProtectionProvider, options, logger)
        {
        }
        public override Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            return base.GenerateAsync(purpose, manager, user);
        }

        public override Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
        {
            return base.ValidateAsync(purpose, token, manager, user);
        }
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return base.CanGenerateTwoFactorTokenAsync(manager, user);
        }
    }
}
