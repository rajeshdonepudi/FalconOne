using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class EmployeeSummary : ITrackableEntity
    {
        public EmployeeSummary()
        {
            EmployeeInterests = new HashSet<Interest>();
            EmployeeHobbies = new HashSet<Hobby>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string AboutJob { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Interest> EmployeeInterests  { get; set; }
        public virtual ICollection<Hobby> EmployeeHobbies { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
