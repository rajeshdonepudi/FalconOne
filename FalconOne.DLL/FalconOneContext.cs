using FalconOne.DLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DLL
{
    public class FalconOneContext : IdentityDbContext<User, UserRole, string>
    {
        public DbSet<RequestInformation> RequestInformation { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        public FalconOneContext(DbContextOptions<FalconOneContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
