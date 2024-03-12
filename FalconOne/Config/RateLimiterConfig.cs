using Microsoft.AspNetCore.RateLimiting;

namespace FalconOne.API.Config
{
    public static class RateLimiterConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddRateLimiter(rlOptions =>
            {
                rlOptions.AddTokenBucketLimiter("Token", blOptions =>
                {
                    blOptions.TokenLimit = 5;
                    blOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    blOptions.QueueLimit = 5;
                    blOptions.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
                    blOptions.TokensPerPeriod = 1;
                    blOptions.AutoReplenishment = true;
                });
            });
        }
    }
}
