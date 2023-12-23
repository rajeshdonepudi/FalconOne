using FalconOne.Enumerations.Employee;

namespace FalconOne.Models.Entities
{
    public class Employee : User
    {
        public Employee()
        {
            TimeEntries = new HashSet<TimeEntry>();
            ReportingManagers = new HashSet<Employee>();
            OverTimeAuthorizations = new HashSet<OverTimeAuthorization>();
        }
        public long OrganizationIssuedId  { get; set; }
        public Guid DesignationId { get; set; }
        public EmployeeGenderEnum Gender { get; set; } = EmployeeGenderEnum.NotSpecified;
        public DateTime DateOfBirth { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; } = MaritalStatusEnum.NotSpecified;
        public BloodGroupTypeEnum BloodGroup { get; set; } = BloodGroupTypeEnum.NotSpecified;
        public bool PhysicallyChallenged { get; set; }
        public string? ProfessionalSummary { get; set; }
        public virtual Designation Designation { get; set; }
        public Guid? JobDetailsId { get; set; }
        public Guid? EmployeeSummaryId { get; set; }
        public virtual EmployeeSummary EmployeeSummary { get; set; }
        public virtual JobDetail JobDetails { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
        public virtual ICollection<Employee> ReportingManagers { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ContactDetail ContactDetails { get; set; }
        public virtual ICollection<OverTimeAuthorization> OverTimeAuthorizations { get; set; }
        public virtual ICollection<MetadataGroup> AdditionalInfo { get; set; }
    }
}
