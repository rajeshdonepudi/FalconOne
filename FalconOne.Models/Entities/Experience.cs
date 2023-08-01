using FalconOne.Enumerations.Employee;

namespace FalconOne.Models.Entities
{
    public class Experience
    {
        public Experience()
        {
            Skills = new HashSet<Skill>();
            Media = new HashSet<Media>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; }
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
    }
}
