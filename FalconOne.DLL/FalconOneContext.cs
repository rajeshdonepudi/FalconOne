using FalconOne.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL
{
    public class FalconOneContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<RequestInformation> RequestInformations { get; set; }
        public DbSet<ApplicationClaim> ApplicationClaims { get; set; }
        public DbSet<ApplicationPolicy> ApplicationPolicies { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
