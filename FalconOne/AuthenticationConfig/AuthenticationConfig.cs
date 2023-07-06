using FalconOne.DAL;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FalconOne.API.AuthenticationConfig
{
    public class FalconOneEmailConfirmationTokenProviderOptions
   : DataProtectionTokenProviderOptions
    {
        public FalconOneEmailConfirmationTokenProviderOptions()
        {
            Name = "FalconOneEmailConfirmationTokenProvider";
            TokenLifespan = TimeSpan.FromMinutes(15);
        }
    }
    public class FalconOneEmailConfirmationTokenProvider<TUser>
    : DataProtectorTokenProvider<TUser> where TUser : class
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
    public static class AuthenticationConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, SecurityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };

                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.Stores.MaxLengthForKeys = 6;

            }).AddEntityFrameworkStores<FalconOneContext>()
              .AddDefaultTokenProviders()
              .AddTokenProvider<FalconOneEmailConfirmationTokenProvider<User>>("FalconOneEmailConfirmationTokenProvider");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //builder.Services.AddAuthentication().AddMicrosoftAccount(opt =>
            //{
            //    opt.ClientId = "1234567890-abc123def456.apps.googleusercontent.com";
            //    opt.ClientSecret = "1234567890-abc123def456.apps.googleusercontent.com";
            //});
        }
    }
}
