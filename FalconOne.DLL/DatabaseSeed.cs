using FalconOne.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FalconOne.DAL
{
    public static class DatabaseSeed
    {
        static Guid tenantId = Guid.NewGuid();

        static Guid departmentId = Guid.NewGuid();

        static Guid locationId = Guid.NewGuid();

        static Guid employeeId = Guid.NewGuid();

        public static void Seed(ModelBuilder modelBuilder)
        {
            var tenant = new Tenant
            {
                Name = "rajesh",
                Host = "rajeshdnp.com",
                CreatedOn = DateTime.UtcNow,
                Id = tenantId,
                LocationId = locationId
            };

            var location = new Location
            {
                Id = locationId,
                Name = "Hyderabad",
                Longitude = "17.3850° N",
                Latitude = "78.4867° E",
            };

            modelBuilder.Entity<Location>().HasData(location);

            modelBuilder.Entity<Tenant>().HasData(tenant);

            var dep = new Department
            {
                Id = departmentId,
                Name = "Development",
                CreatedOn = DateTime.UtcNow,
                TenantId = tenantId,
                LocationId = locationId
            };

            modelBuilder.Entity<Department>().HasData(dep);

            var user = new Employee
            {
                Id = employeeId,
                FirstName = "Rajesh",
                LastName = "Donepudi",
                EmailConfirmed = true,
                Email = "rajesh.dnp01@gmail.com",
                PhoneNumber = "8886014996",
                UserName = "rajesh.dnp01",
                NormalizedEmail = "rajesh.dnp01@gmail.com".Normalize(),
                NormalizedUserName = "rajesh.dnp01".Normalize(),
                DepartmentId = departmentId,
                CreatedOn = DateTime.UtcNow,
                TenantId = tenantId
            };

            user.PasswordHash = new PasswordHasher<IdentityUser<Guid>>().HashPassword(user, "@Raj@123");

            modelBuilder.Entity<Employee>().HasData(user);

            modelBuilder.Entity<ApplicationPolicy>()
                .HasData(new ApplicationPolicy
                {
                    Id = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    Name = "user-policy",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                },
                new ApplicationPolicy
                {
                    Id = Guid.Parse("B7538A53-D3B2-4B66-BA40-97619CDA8D00"),
                    Name = "admin-policy",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                });

            modelBuilder.Entity<ApplicationClaim>()
                .HasData(new ApplicationClaim
                {
                    Id = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    Name = "user-claim",
                    Type = ClaimTypes.Actor,
                    Values = "can-login,can-signup,can-reset-password,can-create-account",
                    ApplicationPolicyId = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId
                });

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
        }
    }
}
