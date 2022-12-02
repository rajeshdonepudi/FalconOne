using FalconOne.DLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FalconOne.DLL
{
    public static class DatabaseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var user = new User
            {
                FirstName = "Rajesh",
                LastName = "Donepudi",
                EmailConfirmed = true,
                Email = "rajesh.dnp01@gmail.com",
                PhoneNumber = "8886014996",
                UserName = "rajesh.dnp01",
                NormalizedEmail = "rajesh.dnp01@gmail.com".Normalize(),
                NormalizedUserName = "rajesh.dnp01".Normalize()
            };

            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, "@Raj@123");

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<ApplicationPolicy>()
                .HasData(new ApplicationPolicy
                {
                    Id = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    Name = "user-policy"
                }, new ApplicationPolicy
                {
                    Id = Guid.Parse("B7538A53-D3B2-4B66-BA40-97619CDA8D00"),
                    Name = "admin-policy"
                });

            modelBuilder.Entity<ApplicationClaim>()
                .HasData(new ApplicationClaim
                {
                    Id = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    Name = "user-claim",
                    Type = ClaimTypes.Actor,
                    Values = "can-login,can-signup,can-reset-password,can-create-account",
                    ApplicationPolicyId = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14")
                });

            modelBuilder.Entity<Navigation>()
                .HasData(new Navigation
                {
                    Id = Guid.NewGuid(),
                    Name = "Login",
                    URL = "login",
                    Description = "User login",
                    ApplicationClaimId = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF")
                },
                new Navigation
                {
                    Id = Guid.NewGuid(),
                    Name = "Singup",
                    URL = "signup",
                    Description = "User signup",
                    ApplicationClaimId = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF")
                });
        }
    }
}
