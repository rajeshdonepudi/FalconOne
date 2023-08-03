using FalconOne.Helpers.Helpers;
using FalconOne.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL
{
    public static class DatabaseSeed
    {
        static readonly Guid tenantId1 = Guid.NewGuid();
        static readonly Guid tenantId2 = Guid.NewGuid();

        static readonly Guid departmentId1 = Guid.NewGuid();
        static readonly Guid departmentId2 = Guid.NewGuid();

        static readonly Guid locationId1 = Guid.NewGuid();
        static readonly Guid locationId2 = Guid.NewGuid();
        static readonly Guid locationId3 = Guid.NewGuid();
        static readonly Guid locationId4 = Guid.NewGuid();
        static readonly Guid designationId1 = Guid.NewGuid();
        static readonly Guid designationId2 = Guid.NewGuid();

        static readonly Guid userId1 = Guid.Parse("5090B588-6E3F-464A-994D-9CD2AF4A0198");

        static readonly Guid userId2 = Guid.Parse("6521474A-6E39-4A5E-8628-CD89B4E922BC");

        public static void Seed(ModelBuilder modelBuilder)
        {
            #region Create location
            Location location1 = new()
            {
                Id = locationId1,
                Name = "Hyderabad",
                Longitude = "17.3850° N",
                Latitude = "78.4867° E",
            };

            Location location2 = new Location
            {
                Id = locationId2,
                Latitude = "16.5102716",
                Longitude = "80.4889922",
                Name = "Vijayawada"
            };

            var location3 = new Location
            {
                Id  = locationId3,
                Latitude = "16.5102716",
                Longitude = "80.4889922",
                Name = "Hitech City"
            };

            var location4 = new Location
            {
                Id = locationId4,
                Latitude = "16.5102716",
                Longitude = "80.4889922",
                Name = "Nidamanuru"
            };

            modelBuilder.Entity<Location>().HasData(location1);
            modelBuilder.Entity<Location>().HasData(location2);
            modelBuilder.Entity<Location>().HasData(location3);
            modelBuilder.Entity<Location>().HasData(location4);

            #endregion

            #region Create department
            Department department = new()
            {
                Id = departmentId1,
                Name = "Development",
                CreatedOn = DateTime.UtcNow,
                TenantId = tenantId1
            };

            Department department2 = new()
            {
                Id = departmentId2,
                Name = ".NET",
                CreatedOn = DateTime.UtcNow,
                TenantId = tenantId2
            };

            var departmentLocations = new List<DepartmentLocation>
            {
                new DepartmentLocation { DepartmentId = departmentId1, LocationId = locationId3 },
                new DepartmentLocation { DepartmentId = departmentId2, LocationId = locationId4 },
            };

            modelBuilder.Entity<Department>().HasData(department);
            modelBuilder.Entity<Department>().HasData(department2);
            modelBuilder.Entity<DepartmentLocation>().HasData(departmentLocations);
            #endregion

            #region Designation
            var designation1 = new Designation
            {
                Id = designationId1,
                Name = "Trainee Engineer",
            };

            var designation2 = new Designation
            {
                Id = designationId2,
                Name = "Associate Software Engineer"
            };

            modelBuilder.Entity<Designation>().HasData(designation1);
            modelBuilder.Entity<Designation>().HasData(designation2);
            #endregion

            #region Create users

            var user1 = new Employee()
            {
                Id = userId2,
                FirstName = "Basic",
                LastName = "User",
                EmailConfirmed = true,
                DesignationId = designationId1,
                OrganizationIssuedId = 1,
                Email = "b@b.com",
                IsActive = true,
                ResourceId = 1,
                PhoneNumber = "8886014996",
                UserName = "basicuser01",
                NormalizedEmail = "b@b.com".Normalize(),
                NormalizedUserName = "b".Normalize(),
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "UCQO32XEFNXIAZIR3LTNFDRRX7A2NHLK",
                PasswordHash = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                ConcurrencyStamp = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
            };

            var user2 = new Employee()
            {
                Id = userId1,
                FirstName = "Admin",
                LastName = "User",
                CreatedOn = DateTime.UtcNow,
                OrganizationIssuedId = 2,
                DesignationId = designationId2,
                EmailConfirmed = true,
                ResourceId = 2,
                IsActive = true,
                Email = "a@a.com",
                UserName = "adminuser01",
                NormalizedEmail = "a@a.com".Normalize(),
                NormalizedUserName = "a".Normalize(),
                SecurityStamp = "UCQO32XEFNXIAZIR3LTNFDRRX7A2NHLK",
                PasswordHash = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                ConcurrencyStamp = "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==",
                PhoneNumber = "8886014997",
            };

            

            user1.PasswordHash = PasswordHasher.HashPassword(user1, "@Raj@123");
            user2.PasswordHash = PasswordHasher.HashPassword(user2, "@Raj@123");

            modelBuilder.Entity<Employee>().HasData(user1);
            modelBuilder.Entity<Employee>().HasData(user2);
            modelBuilder.Entity<EmployeeDepartment>().HasData(new EmployeeDepartment
            {
                DepartmentId = departmentId1,
                EmployeeId = userId1
            });
            modelBuilder.Entity<EmployeeDepartment>().HasData(new EmployeeDepartment
            {
                DepartmentId = departmentId2,
                EmployeeId = userId2
            });
            #endregion

            #region Create tenant1
            Tenant tenant1 = new()
            {
                Name = "development",
                Host = "localhost",
                CreatedOn = DateTime.UtcNow,
                Id = tenantId1,
            };

            Tenant tenant2 = new()
            {
                Name = "FalconOne",
                Host = "api.falconone.com",
                CreatedOn = DateTime.UtcNow,
                Id = tenantId2,
            };

            modelBuilder.Entity<TenantUser>().HasNoKey().HasData(
                new TenantUser
                {
                    TenantId = tenantId1,
                    UserId = userId1
                },
                new TenantUser
                {
                    TenantId = tenantId1,
                    UserId = userId2
                },
                new TenantUser
                {
                    TenantId = tenantId2,
                    UserId = userId1
                },
                new TenantUser
                {
                    TenantId = tenantId2,
                    UserId = userId2
                }
            );

            modelBuilder.Entity<Tenant>().HasData(tenant1);
            modelBuilder.Entity<Tenant>().HasData(tenant2);
            modelBuilder.Entity<TenantLocation>().HasData(new TenantLocation
            {
                TenantId = tenantId1,
                LocationId = locationId1
            });
            modelBuilder.Entity<TenantLocation>().HasData(new TenantLocation
            {
                TenantId = tenantId2,
                LocationId = locationId2
            });
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

            modelBuilder.Entity<SecurityPolicy>()
                .HasData(new SecurityPolicy
                {
                    Id = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    Name = "User",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId1
                },
                new SecurityPolicy
                {
                    Id = Guid.Parse("B7538A53-D3B2-4B66-BA40-97619CDA8D00"),
                    Name = "Admin",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId1
                });

            #endregion

            #region Create application claims

            modelBuilder.Entity<SecurityClaim>()
                .HasData(new SecurityClaim
                {
                    Id = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    Type = "Admin",
                    Value = "Everything",
                    ApplicationPolicyId = Guid.Parse("B7538A53-D3B2-4B66-BA40-97619CDA8D00"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId1,
                    Description = "Database seeded"
                });

            modelBuilder.Entity<SecurityClaim>()
                .HasData(new SecurityClaim
                {
                    Id = Guid.NewGuid(),
                    Type = "User",
                    Value = "BasicThings",
                    ApplicationPolicyId = Guid.Parse("9FA14D9E-0D8E-4B51-85E4-C4BDD5873D14"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId1,
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
                    TenantId = tenantId1
                },
                new Navigation
                {
                    Id = Guid.NewGuid(),
                    Name = "Singup",
                    URL = "signup",
                    Description = "User signup",
                    ApplicationClaimId = Guid.Parse("C1F09DF3-5590-4EE8-9B8C-D0315369A7AF"),
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId1
                });

            #endregion

            #region Default theme settings
            modelBuilder.Entity<SiteSetting>().HasData(new SiteSetting
            {
                Id = Guid.NewGuid(),
                SettingType = Enumerations.Settings.SystemSettingTypeEnum.Theme,
                CreatedOn = DateTime.UtcNow,
                DisplayName = "Primary Color",
                Description = "This is primary color",
                Name = "primaryColor",
                Value = "#144272",
                TenantId = tenantId1
            });

            modelBuilder.Entity<SiteSetting>().HasData(new SiteSetting
            {
                Id = Guid.NewGuid(),
                SettingType = Enumerations.Settings.SystemSettingTypeEnum.Theme,
                CreatedOn = DateTime.UtcNow,
                Description = "This is secondary color",
                DisplayName = "Secondary Color",
                Name = "secondaryColor",
                Value = "#205295",
                TenantId = tenantId1
            });

            modelBuilder.Entity<SiteSetting>().HasData(new SiteSetting
            {
                Id = Guid.NewGuid(),
                SettingType = Enumerations.Settings.SystemSettingTypeEnum.Theme,
                CreatedOn = DateTime.UtcNow,
                Description = "This is site theme",
                DisplayName = "Theme",
                Name = "theme",
                Value = "light",
                TenantId = tenantId1
            });

            modelBuilder.Entity<SiteSetting>().HasData(new SiteSetting
            {
                Id = Guid.NewGuid(),
                SettingType = Enumerations.Settings.SystemSettingTypeEnum.Theme,
                CreatedOn = DateTime.UtcNow,
                Description = "This is primary color",
                DisplayName = "Primary Color",
                Name = "primaryColor",
                Value = "#144272",
                TenantId = tenantId2
            });

            modelBuilder.Entity<SiteSetting>().HasData(new SiteSetting
            {
                Id = Guid.NewGuid(),
                SettingType = FalconOne.Enumerations.Settings.SystemSettingTypeEnum.Theme,
                CreatedOn = DateTime.UtcNow,
                Description = "This is secondary color",
                Name = "secondaryColor",
                DisplayName = "Secondary Color",
                Value = "#205295",
                TenantId = tenantId2
            });

            modelBuilder.Entity<SiteSetting>().HasData(new SiteSetting
            {
                Id = Guid.NewGuid(),
                SettingType = Enumerations.Settings.SystemSettingTypeEnum.Theme,
                CreatedOn = DateTime.UtcNow,
                Description = "This is site theme",
                Name = "theme",
                Value = "light",
                DisplayName = "Theme",
                TenantId = tenantId2
            });
            #endregion

            #region Posts
            modelBuilder.Entity<Post>()
                .HasData(new Post
                {
                    Id = Guid.NewGuid(),
                    Content = "Hey this is new post on our site.",
                    CreatedOn = DateTime.UtcNow,
                    TenantId = tenantId1,
                    PostedById = userId1,
                    PostedOn = DateTime.UtcNow
                });
            #endregion
        }
    }
}
