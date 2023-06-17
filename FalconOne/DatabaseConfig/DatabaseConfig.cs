﻿using FalconOne.DAL;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.API.DatabaseConfig
{
    public static class DatabaseConfig
    {
        public static void Configure(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                FalconOneContext? context = scope.ServiceProvider.GetService<FalconOneContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
