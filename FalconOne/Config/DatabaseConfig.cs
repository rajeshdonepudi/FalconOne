using FalconOne.DAL;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.API.Config
{
    public static class DatabaseConfig
    {
        public static void Configure(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                FalconOneContext? context = scope.ServiceProvider.GetService<FalconOneContext>();

                if (context is not null)
                {
                    bool hasPendingMigrations = context.Database.GetPendingMigrations().Any();

                    if (hasPendingMigrations)
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
