using Microsoft.AspNetCore.Identity;

namespace FalconOne.API.Providers
{
    public class FalconOneEmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public FalconOneEmailConfirmationTokenProviderOptions()
        {
            Name = "FalconOneEmailConfirmationTokenProvider";
            TokenLifespan = TimeSpan.FromMinutes(15);
        }
    }
}
