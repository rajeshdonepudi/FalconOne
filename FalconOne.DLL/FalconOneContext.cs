using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL
{
    public class FalconOneContext : IdentityDbContext<User, SecurityRole, Guid>
    {
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<TenantUser> TenantUsers { get; set; }
        public DbSet<TenantUserRole> TenantUserRoles { get; set; }

        public FalconOneContext()
        {

        }

        public FalconOneContext(DbContextOptions<FalconOneContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            EntityConfiguration(modelBuilder);
        }

        private static void EntityConfiguration(ModelBuilder builder)
        {
            #region Tenants

            builder.Entity<Tenant>()
                   .Property(a => a.AccountAlias)
                   .HasColumnType("nvarchar(max)")
                   .HasComputedColumnSql($"CONVERT(NVARCHAR(max), {GenerateTimeBasedId()}) + '-FALO_TEN' + CAST([AccountId] AS NVARCHAR(max))");

            #endregion

            #region User

            builder.Entity<User>()
                   .HasAlternateKey(x => x.ResourceId);

            builder.Entity<User>()
                   .Property(x => x.ResourceAlias)
                   .HasColumnType("nvarchar(max)")
                   .HasComputedColumnSql($"CONVERT(NVARCHAR(max), {GenerateTimeBasedId()}) + '-FALO_USR' + CAST([ResourceId] AS NVARCHAR(max))");
            #endregion
        }

        public static string GenerateTimeBasedId()
        {
            DateTime now = DateTime.UtcNow;

            string id = now.ToString("yyyyMMddHHmmssfff");

            return id;
        }
    }
}
