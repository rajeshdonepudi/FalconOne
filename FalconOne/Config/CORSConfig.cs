namespace FalconOne.API.Config
{
    public static class CORSConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "ReactAppOrigin",
                builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .SetIsOriginAllowed((host) => true)
                           .WithOrigins("http://localhost:3000",
                                        "http://app.falconone.com:5173",
                                        "http://localhost:5173",
                                        "https://localhost:5173",
                                        "https://falcone-one.web.app",
                                        "https://localhost:3000");
                });
            });
        }
    }
}
