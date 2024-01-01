using Bogus;
using Bogus.DataSets;
using FalconOne.Enumerations.Employee;
using FalconOne.Models.Entities;
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
                            .RuleFor(x => x.LegalEntities, f => GenerateLegalEntities(random.Next(1, 5)))
                            .RuleFor(x => x.Users, f => GenerateTenantUsers(random.Next(1, 5)));

            var scope = serviceProvider.CreateScope();

            using (scope)
            {
                var context = scope.ServiceProvider.GetRequiredService<FalconOneContext>();

                if(!context.Tenants.Any())
                {
                    await Task.Factory.StartNew(() =>
                    {
                        for (int i = 1; i < 100; i++)
                        {
                            Console.WriteLine($"----------------------------------------");
                            Console.WriteLine("Started Batch Execution No.: {0}", i);
                            Console.WriteLine($"----------------------------------------");

                            var tenants = tenantFaker.Generate(10);

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
            }
        }

        public static List<TenantUser> GenerateTenantUsers(int count = 1)
        {
            var tenantUserFaker = new Faker<TenantUser>()
               .RuleFor(x => x.User, f => GenerateUsers().FirstOrDefault());

            return tenantUserFaker.Generate(count);
        }

        public static List<User> GenerateUsers(int count = 1)
        {
            var userFaker = new Faker<User>()
                            .RuleFor(u => u.UserName, f => f.Person.UserName)
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
                            .RuleFor(u => u.PhysicallyChallenged, f => f.PickRandom<bool>())
                            .RuleFor(u => u.ProfessionalSummary, f => f.Lorem.Paragraph(1))
                            .RuleFor(u => u.DateOfBirth, f => f.Date.Past())
                            .RuleFor(u => u.IsActive, f => f.Random.Bool())
                            .RuleFor(u => u.ModifiedOn, f => f.Date.Past())
                            .RuleFor(u => u.CreatedOn, f => f.Date.Past())
                            .RuleFor(u => u.ProfilePictureId, f => f.Random.Guid())
                            .RuleFor(u => u.JobDetails, f => GetJobDetail())
                            .RuleFor(u => u.EmployeeSummary, f => GetEmployeeSummary())
                            .RuleFor(t => t.ProfilePicture, (f, p) => new Image
                            {
                                Data = Encoding.UTF8.GetBytes(f.Image.LoremPixelUrl(LoremPixelCategory.People)),
                                Title = f.Name.Random.AlphaNumeric(9)
                            })
                            .RuleFor(u => u.TenantUsers, f => new List<TenantUser>());

            return userFaker.Generate(count);
        }


        public static List<Department> GenerateDepartments(int count = 1)
        {
            var departmentFaker = new Faker<Department>()
                                      .RuleFor(x => x.Name, f => f.Commerce.Department())
                                      .RuleFor(t => t.ProfilePicture, (f, p) => new Image
                                      {
                                          Data = Encoding.UTF8.GetBytes(f.Image.LoremPixelUrl(LoremPixelCategory.Abstract)),
                                          Title = f.Name.Random.AlphaNumeric(9)
                                      });

            return departmentFaker.Generate(count);
        }

        public static List<LegalEntity> GenerateLegalEntities(int count = 1)
        {
            var random = new Random();

            var legalEntityFaker = new Faker<LegalEntity>()
                                    .RuleFor(x => x.Name, f => f.Company.CompanyName())
                                    .RuleFor(x => x.LegalName, f => f.Company.CompanyName())
                                    .RuleFor(x => x.CompanyIdentificationNumber, f => f.Random.Number(100000, 999999))
                                    .RuleFor(x => x.DateOfIncorporation, f => f.Date.Past())
                                    .RuleFor(x => x.BusinessType, f => f.PickRandom<BusinessTypeEnum>())
                                    .RuleFor(x => x.Sector, f => f.PickRandom<ServiceSectorEnum>())
                                    .RuleFor(x => x.NatureOfBusiness, f => f.PickRandom<NatureOfBusinessEnum>())
                                    .RuleFor(x => x.ModifiedOn, f => f.Date.Past())
                                    .RuleFor(x => x.CreatedOn, f => f.Date.Recent())
                                    .RuleFor(x => x.AddressLine1, f => f.Address.StreetAddress())
                                    .RuleFor(x => x.AddressLine2, f => f.Address.SecondaryAddress())
                                    .RuleFor(x => x.City, f => f.Address.City())
                                    .RuleFor(x => x.Designations, f => GenerateDesignations(random.Next(1, 10)))
                                    .RuleFor(x => x.State, f => f.Address.State())
                                    .RuleFor(x => x.BusinessUnits, f => GenerateBusinessUnits(5))
                                    .RuleFor(x => x.ZipCode, f => f.Address.ZipCode());

            return legalEntityFaker.Generate(count);
        }

        public static JobDetail GetJobDetail()
        {
            var jobDetailFaker = new Faker<JobDetail>()
                                 .RuleFor(j => j.Id, f => f.Random.Guid())
                                 .RuleFor(j => j.DateOfJoining, f => f.Date.Past())
                                 .RuleFor(j => j.EmploymentType, f => f.PickRandom<EmploymentTypeEnum>())
                                 .RuleFor(j => j.WorkerType, f => f.PickRandom<WorkerTypeEnum>())
                                 .RuleFor(j => j.TimeType, f => f.PickRandom<TimeTypeEnum>())
                                 .RuleFor(j => j.EmployeeBand, f => f.PickRandom<EmployeeBandEnum>())
                                 .RuleFor(j => j.PayGrade, f => f.PickRandom<EmployeePayGradeEnum>());

            return jobDetailFaker.Generate();
        }

        public static EmployeeSummary GetEmployeeSummary()
        {
            var employeeSummaryFaker = new Faker<EmployeeSummary>()
                                           .RuleFor(e => e.Id, f => f.Random.Guid())
                                           .RuleFor(e => e.Description, f => f.Lorem.Sentence())
                                           .RuleFor(e => e.AboutJob, f => f.Lorem.Paragraph())
                                           .RuleFor(e => e.EmployeeInterests, f => new HashSet<Interest>())
                                           .RuleFor(e => e.EmployeeHobbies, f => new HashSet<Hobby>());

            return employeeSummaryFaker.Generate();
        }

        public static List<BusinessUnit> GenerateBusinessUnits(int count = 1)
        {
            var DivisionNames = new List<string> { "Engineering", "Products Division", "Sales Division", "Marketing Division", "IT Division" };

            var random = new Random();

            var businessUnitfaker = new Faker<BusinessUnit>()
                                       .RuleFor(u => u.ModifiedOn, f => f.Date.Past())
                                       .RuleFor(u => u.CreatedOn, f => f.Date.Past())
                                       .RuleFor(b => b.Locations, f => GenerateLocatios(random.Next(1, 5)))
                                       .RuleFor(b => b.Name, f => f.PickRandom(DivisionNames));

            return businessUnitfaker.Generate(count);
        }

        public static List<Location> GenerateLocatios(int count = 1)
        {

            var random = new Random();

            var locationFaker = new Faker<Location>()
                 .RuleFor(u => u.ModifiedOn, f => f.Date.Past())
                 .RuleFor(u => u.CreatedOn, f => f.Date.Past())
                 .RuleFor(x => x.Name, f => f.Address.City())
                 .RuleFor(x => x.Latitude, f => f.Address.Latitude())
                 .RuleFor(x => x.Longitude, f => f.Address.Longitude())
                 .RuleFor(x => x.Departments, f => GenerateDepartment(random.Next(1, 20)));

            return locationFaker.Generate(count);
        }

        public static List<Department> GenerateDepartment(int count = 1)
        {
            var departmentNames = new List<string>
                                  {
                                      "Human Resources",
                                      "Marketing",
                                      "Finance",
                                      "Information Technology",
                                      "Sales",
                                      "Customer Service",
                                      "Research and Development",
                                      "Operations",
                                      "Administration",
                                      "Legal",
                                      "Procurement",
                                      "Quality Assurance",
                                      "Engineering",
                                      "Product Development",
                                      "Public Relations",
                                      "Training and Development",
                                      "Logistics",
                                      "Compliance",
                                      "Facilities Management",
                                      "Health and Safety"
                                  };

            var departmentFaker = new Faker<Department>()
                                     .RuleFor(d => d.Name, f => f.PickRandom(departmentNames))
                                     .RuleFor(u => u.ModifiedOn, f => f.Date.Past())
                                     .RuleFor(u => u.CreatedOn, f => f.Date.Past())
                                     .RuleFor(t => t.ProfilePicture, (f, p) => new Image
                                     {
                                         Data = Encoding.UTF8.GetBytes(f.Image.LoremPixelUrl(LoremPixelCategory.Business)),
                                         Title = f.Name.Random.AlphaNumeric(9)
                                     });

            return departmentFaker.Generate(count);
        }

        public static List<Designation> GenerateDesignations(int count = 1)
        {
            var faker = new Faker<Designation>()
                           .RuleFor(d => d.Id, f => f.Random.Guid())
                           .RuleFor(d => d.Name, f => f.Name.JobTitle());

            return faker.Generate(count);
        }
    }
}
