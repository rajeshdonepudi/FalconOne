namespace FalconOne.API.AuthorizationConfig
{
    public static class AuthorizationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {

            });
        }
    }
}
