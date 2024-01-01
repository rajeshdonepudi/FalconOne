using FalconOne.Enumerations.Employee;
using FalconOne.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class User : IdentityUser<Guid>, ITrackableEntity
    {
        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;

            RefreshTokens = new List<RefreshToken>();
            TenantUsers = new HashSet<TenantUser>();

            TimeEntries = new HashSet<TimeEntry>();
            ReportingManagers = new HashSet<User>();
            OverTimeAuthorizations = new HashSet<OverTimeAuthorization>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public bool IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ResourceAlias { get; private set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public virtual Image? ProfilePicture { get; set; }

        public Guid DesignationId { get; set; }
        public EmployeeGenderEnum Gender { get; set; } = EmployeeGenderEnum.NotSpecified;
        public DateTime DateOfBirth { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; } = MaritalStatusEnum.NotSpecified;
        public BloodGroupTypeEnum BloodGroup { get; set; } = BloodGroupTypeEnum.NotSpecified;
        public bool PhysicallyChallenged { get; set; }
        public string? ProfessionalSummary { get; set; }
        public Guid? JobDetailsId { get; set; }
        public Guid? EmployeeSummaryId { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual EmployeeSummary EmployeeSummary { get; set; }
        public virtual JobDetail JobDetails { get; set; }
        public virtual ContactDetail ContactDetails { get; set; }

        public virtual ICollection<TenantUser> TenantUsers { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
        public virtual ICollection<User> ReportingManagers { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<OverTimeAuthorization> OverTimeAuthorizations { get; set; }
        public virtual ICollection<MetadataGroup> AdditionalInfo { get; set; }
        public bool OwnsToken(string token)
        {
            return RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
