namespace FalconOne.API.Config
{
    public static class CacheConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache(o =>
            {
                o.TrackStatistics = true;
            });
        }
    }
}
