using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FalconOne.Models.EntityConfiguration;

namespace FalconOne.DAL
{
    public class FalconOneContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<SecurityClaim> SecurityClaims { get; set; }
        public DbSet<SecurityPolicy> SecurityPolicies { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<TimeEntry> AttendanceLogs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Image> Images { get; set; }

        public FalconOneContext()
        {

        }

        public FalconOneContext(DbContextOptions<FalconOneContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DatabaseSeed.Seed(modelBuilder);
            ApplyEntityConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ApplyEntityConfigurations(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TenantUserConfiguration());
        }
    }
}
