using FalconOne.Enumerations.Employee;
using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class Experience : ITrackableEntity
    {
        public Experience()
        {
            Skills = new HashSet<Skill>();
            Media = new HashSet<Media>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; } = EmploymentTypeEnum.NotSpecified;
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public WorkLocationType LocationType { get; set; }
        public bool IsCurrentJob { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool EndPreviousPosition { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }
        public string ProfileHeadline { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
