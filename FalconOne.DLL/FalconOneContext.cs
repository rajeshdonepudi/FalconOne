using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL
{
    public class FalconOneContext : IdentityDbContext<User, SecurityRole, Guid>
    {
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public FalconOneContext()
        {

        }

        public FalconOneContext(DbContextOptions<FalconOneContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  DatabaseSeed.Seed(modelBuilder);
            ApplyEntityConfigurations(modelBuilder);
            EntityConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void EntityConfiguration(ModelBuilder builder)
        {
            #region Tenants

            builder.Entity<Tenant>()
                   .Property(a => a.AccountAlias)
                   .HasComputedColumnSql($"{GenerateTimeBasedId()}-'FOTEN' + CAST([AccountId] AS nvarchar(max))");

            #endregion

            #region User

            builder.Entity<User>()
                   .HasAlternateKey(x => x.ResourceId);

            builder.Entity<User>()
                   .Property(x => x.ResourceAlias)
                   .HasComputedColumnSql($"{GenerateTimeBasedId()}-'FOUSR' + CAST([ResourceId] AS nvarchar(max))");
            #endregion


        }

        private void ApplyEntityConfigurations(ModelBuilder builder)
        {
        }

        public static string GenerateTimeBasedId()
        {
            DateTime now = DateTime.UtcNow;

            string id = now.ToString("yyyyMMddHHmmssfff");

            return id;
        }
    }
}
