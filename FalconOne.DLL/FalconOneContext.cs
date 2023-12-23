using FalconOne.Models.Entities;
using FalconOne.Models.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.DAL
{
    public class FalconOneContext : IdentityDbContext<User, SecurityRole, Guid>
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
        public DbSet<Country> Countries { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Address> Addressess { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<WeekOffPolicy> WeekOffPolicies { get; set; }
        public DbSet<PolicyDay> PolicyDays { get; set; }
        public DbSet<AttendanceTrackingPolicy> AttendanceTrackingPolicies { get; set; }
        public DbSet<RemoteWorkEligibilityCriteria> RemoteWorkEligibilityCriteria { get; set; }
        public DbSet<OverTimePolicy> OverTimePolicies { get; set; }
        public DbSet<OverTimeAuthorization> OverTimeAuthorizations { get; set; }
        public DbSet<BreakAndMealPeriod> BreakAndMealPeriods { get; set; }
        public DbSet<AbsenceAndLeavePolicy> AbsenceAndLeavePolicies { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<EmployeeTime> EmployeeTimes { get; set; }
        public DbSet<ShiftWeeklyOffRule> ShiftWeeklyOffRules { get; set; }
        public DbSet<ShiftAllowancePolicy> ShiftAllowancePolicies { get; set; }
        public DbSet<AttendanceCaptureScheme> AttendanceCaptureSchemes { get; set; }
        public DbSet<AttendanceCaptureMethod> AttendanceCaptureMethods { get; set; }
        public DbSet<HolidayCalendar> HolidayCalendars { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<MetadataGroup> MetadataGroups { get; set; }
        public DbSet<Metadata> Metadatas { get; set; }
        public DbSet<EmployeeSummary> EmployeeSummaries { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<LeavePlan> LeavePlans { get; set; }
        public DbSet<Designation> Designations { get; set; } 

        public FalconOneContext()
        {

        }

        public FalconOneContext(DbContextOptions<FalconOneContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  DatabaseSeed.Seed(modelBuilder);
            ApplyEntityConfigurations(modelBuilder);
            EntityConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void EntityConfiguration(ModelBuilder builder)
        {
            #region Tenants
            
            builder.Entity<Tenant>()
       .Property(a => a.AccountAlias)
       .HasComputedColumnSql("'FOTEN' + CAST([AccountId] AS nvarchar(max))");

            #endregion

            #region User
            builder.Entity<User>()
                   .HasDiscriminator<string>("Discriminator")
                   .HasValue<Employee>("Employee");

            builder.Entity<User>()
                   .HasAlternateKey(x => x.ResourceId);

            builder.Entity<User>()
                   .Property(x => x.ResourceAlias)
                   .HasComputedColumnSql("'FOUSR' + CAST([ResourceId] AS nvarchar(max))");
            #endregion

            #region Employees
            builder.Entity<Employee>()
                   .Property(p => p.OrganizationIssuedId)
                   .ValueGeneratedNever();
            #endregion

            #region Policies
            builder.Entity<OverTimeAuthorization>()
                   .HasOne(e => e.RequestedBy)
                   .WithMany(e => e.OverTimeAuthorizations)
                   .HasForeignKey(e => e.RequestedById)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }

        private void ApplyEntityConfigurations(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TenantUserConfiguration());
            builder.ApplyConfiguration(new EmployeeTimeConfiguration());
            
        }
    }
}
