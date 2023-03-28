using FalconOne.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utilities.Helpers;

namespace FalconOne.DAL
{
    public static class DatabaseSeed
    {
        static Guid tenantId = Guid.NewGuid();

        static Guid departmentId = Guid.NewGuid();

        static Guid locationId = Guid.NewGuid();

        static Guid userId1 = Guid.Parse("5090B588-6E3F-464A-994D-9CD2AF4A0198");

        static Guid userId2 = Guid.Parse("6521474A-6E39-4A5E-8628-CD89B4E922BC");

        public static void Seed(ModelBuilder modelBuilder)
        {
            #region Create location
            var location = new Location
            {
                Id = locationId,
                Name = "Hyderabad",
                Longitude = "17.3850° N",
                Latitude = "78.4867° E",
            };

            modelBuilder.Entity<Location>().HasData(location);
            #endregion

            #region Create tenant
            var tenant = new Tenant
            {
                Name = "rajesh",
                Host = "rajeshdnp.com",
                CreatedOn = DateTime.UtcNow,
                Id = tenantId,
                LocationId = locationId
            };

            modelBuilder.Entity<Tenant>().HasData(tenant);
            #endregion

            #region Create department
            var department = new Department
            {
                Id = departmentId,
                Name = "Development",
                CreatedOn = DateTime.UtcNow,
                TenantId = tenantId,
                LocationId = locationId
            };

            modelBuilder.Entity<Department>().HasData(department);
            #endregion

            #region Create users

            var user1 = new User
            {
                Id = userId2,
                FirstName = "Basic",
                LastName = "User",
                EmailConfirmed = true,
                Email = "b@b.com",
                PhoneNumber = "8886014996",
                UserName = "basicuser01",
                NormalizedEmail = "b@b.com".Normalize(),
                NormalizedUserName = "b".Normalize(),
                DepartmentId = departmentId,
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "UCQO32XEFNXIAZIR3LTNFDRRX7A2NHLK",
                PasswordHash = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                ConcurrencyStamp = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                TenantId = tenantId,
            };

            var user2 = new User
            {
                Id = userId1,
                FirstName = "Admin",
                LastName = "User",
                CreatedOn = DateTime.UtcNow,
                TenantId = tenantId,
                EmailConfirmed = true,
                Email = "a@a.com",
                UserName = "adminuser01",
                NormalizedEmail = "a@a.com".Normalize(),
                NormalizedUserName = "a".Normalize(),
                DepartmentId = departmentId,
                SecurityStamp = "UCQO32XEFNXIAZIR3LTNFDRRX7A2NHLK",
                PasswordHash = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                ConcurrencyStamp = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                PhoneNumber = "8886014997",
            };

            user1.PasswordHash = PasswordHasher.HashPassword(user1, "@Raj@123");
            user2.PasswordHash = PasswordHasher.HashPassword(user2, "@Raj@123");

            modelBuilder.Entity<User>().HasData(user1);
            modelBuilder.Entity<User>().HasData(user2);

            #endregion

            #region UserClaims

            modelBuilder.Entity<IdentityUserClaim<Guid>>().HasData(new IdentityUserClaim<Guid>
            {
                Id = 1,
                ClaimType = "Admin",
                ClaimValue = "Everything",
                UserId = userId1,
            },
            new IdentityUserClaim<Guid>
            {
                Id = 2,
                ClaimType = "User",
                ClaimValue = "BasicThings",
                UserId = userId2,
            });

            #endregion

            #region Create application policies

            modelBuilder.Entity<ApplicationPolicy>()
                .HasData(new ApplicationPolicy
                {
                    Id = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    Name = "User",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                },
                new ApplicationPolicy
                {
                    Id = Guid.Parse("B7538A53-D3B2-4B66-BA40-97619CDA8D00"),
                    Name = "Admin",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                });

            #endregion

            #region Create application claims

            modelBuilder.Entity<ApplicationClaim>()
                .HasData(new ApplicationClaim
                {
                    Id = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    Type = "Admin",
                    Value = "Everything",
                    ApplicationPolicyId = Guid.Parse("B7538A53-D3B2-4B66-BA40-97619CDA8D00"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId,
                    Description = "Database seeded"
                });

            modelBuilder.Entity<ApplicationClaim>()
                .HasData(new ApplicationClaim
                {
                    Id = Guid.NewGuid(),
                    Type = "User",
                    Value = "BasicThings",
                    ApplicationPolicyId = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId,
                    Description = "Database seeded"
                });
            #endregion

            #region Create navigation

            modelBuilder.Entity<Navigation>()
                .HasData(new Navigation
                {
                    Id = Guid.NewGuid(),
                    Name = "Login",
                    URL = "login",
                    Description = "User login",
                    ApplicationClaimId = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                },
                new Navigation
                {
                    Id = Guid.NewGuid(),
                    Name = "Singup",
                    URL = "signup",
                    Description = "User signup",
                    ApplicationClaimId = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                });

            #endregion
        }
    }
}
