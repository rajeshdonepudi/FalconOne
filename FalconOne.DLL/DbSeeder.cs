using Bogus;
using Bogus.DataSets;
using FalconOne.Enumerations.Employee;
using FalconOne.Models.Entities;
using FalconOne.Security;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace FalconOne.DAL
{
    public static class DbSeeder
    {
        public async static void Seed(IServiceProvider serviceProvider)
        {
            var random = new Random();

            var tenantFaker = new Faker<Tenant>()
                            .RuleFor(t => t.Name, f => f.Company.CompanyName())
                            .RuleFor(t => t.Host, f => f.Internet.Url())
                            .RuleFor(t => t.CreatedOn, f => f.Date.Past(1))
                            .RuleFor(t => t.ModifiedOn, f => f.Date.Recent())
                            .RuleFor(t => t.ProfilePicture, (f, p) => new Image
                            {
                                Data = Encoding.UTF8.GetBytes(f.Image.LoremPixelUrl(LoremPixelCategory.Business)),
                                Title = f.Name.Random.AlphaNumeric(9)
                            })
                            .RuleFor(x => x.Users, f => GenerateTenantUsers(random.Next(1, 1000)));

            var scope = serviceProvider.CreateScope();

            using (scope)
            {
                var context = scope.ServiceProvider.GetRequiredService<FalconOneContext>();

                if (!context.Tenants.Any())
                {
                    await Task.Factory.StartNew(() =>
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            Console.WriteLine($"----------------------------------------");
                            Console.WriteLine("Started Batch Execution No.: {0}", i);
                            Console.WriteLine($"----------------------------------------");

                            var tenants = tenantFaker.Generate(1);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Tenants Generated for batch: {0}", tenants.Count);
                            Console.ResetColor();

                            context.Tenants.AddRange(tenants);

                            context.SaveChanges();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"------------------------------------");
                            Console.WriteLine("Batch Execution Completed: Batch No.: {0}", i);
                            Console.WriteLine($"------------------------------------");
                            Console.ResetColor();
                        }
                    });
                }

                if (!context.Roles.Any())
                {
                    await context.Roles.AddRangeAsync(GetSecurityRoles());
                    await context.SaveChangesAsync();
                }
            }
        }

        public static List<TenantUser> GenerateTenantUsers(int count = 1)
        {
            var tenantUserFaker = new Faker<TenantUser>()
                                      .RuleFor(x => x.User, f => GenerateUsers().FirstOrDefault());

            return tenantUserFaker.Generate(count);
        }

        public static List<SecurityRole> GetSecurityRoles()
        {
            var roles = new List<SecurityRole>()
            {
                new SecurityRole
                {
                    Name = SecurityRoles.GOD,
                    CreatedOn = DateTime.UtcNow,
                    NormalizedName = SecurityRoles.GOD.ToUpper(),
                },
                new SecurityRole
                {
                    Name = SecurityRoles.TENANT_ADMIN,
                    CreatedOn = DateTime.UtcNow,
                    NormalizedName = SecurityRoles.TENANT_ADMIN.ToUpper()
                },
                new SecurityRole
                {
                    Name = SecurityRoles.TENANT_USER,
                    CreatedOn = DateTime.UtcNow,
                    NormalizedName = SecurityRoles.TENANT_USER.ToUpper()
                }
            };

            return roles;
        }

        public static List<User> GenerateUsers(int count = 1)
        {
            var userFaker = new Faker<User>()
                            .RuleFor(u => u.UserName, f => f.Random.Guid().ToString())
                            .RuleFor(u => u.NormalizedUserName, (f, u) => u?.UserName?.ToUpper())
                            .RuleFor(u => u.Email, (f, u) => f.Person.Email)
                            .RuleFor(u => u.NormalizedEmail, (f, u) => u?.Email?.ToUpper())
                            .RuleFor(u => u.EmailConfirmed, f => f.Random.Bool())
                            .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
                            .RuleFor(u => u.SecurityStamp, f => f.Random.Guid().ToString())
                            .RuleFor(u => u.ConcurrencyStamp, f => f.Random.Guid().ToString())
                            .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
                            .RuleFor(u => u.PhoneNumberConfirmed, f => f.Random.Bool())
                            .RuleFor(u => u.TwoFactorEnabled, f => f.Random.Bool())
                            .RuleFor(u => u.LockoutEnd, f => f.Date.Future())
                            .RuleFor(u => u.LockoutEnabled, f => f.Random.Bool())
                            .RuleFor(u => u.AccessFailedCount, f => f.Random.Number(0, 5))
                            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                            .RuleFor(u => u.LastName, f => f.Person.LastName)
                            .RuleFor(u => u.MiddleName, f => f.Person.FirstName)
                            .RuleFor(u => u.Gender, f => f.PickRandom<EmployeeGenderEnum>())
                            .RuleFor(u => u.MaritalStatus, f => f.PickRandom<MaritalStatusEnum>())
                            .RuleFor(u => u.BloodGroup, f => f.PickRandom<BloodGroupTypeEnum>())
                            .RuleFor(u => u.PhysicallyChallenged, f => f.Random.Bool())
                            .RuleFor(u => u.DateOfBirth, f => f.Date.Past())
                            .RuleFor(u => u.IsActive, f => f.Random.Bool())
                            .RuleFor(u => u.ModifiedOn, f => f.Date.Past())
                            .RuleFor(u => u.CreatedOn, f => f.Date.Past())
                            .RuleFor(u => u.ProfilePictureId, f => f.Random.Guid())
                            .RuleFor(t => t.ProfilePicture, (f, p) => new Image
                            {
                                Data = Encoding.UTF8.GetBytes(f.Image.LoremPixelUrl(LoremPixelCategory.People)),
                                Title = f.Name.Random.AlphaNumeric(9)
                            });

            return userFaker.Generate(count);
        }
    }
}
