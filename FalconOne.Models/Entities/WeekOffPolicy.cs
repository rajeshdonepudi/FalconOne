using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class WeekOffPolicy
    {
        public WeekOffPolicy()
        {
            PolicyDays = new HashSet<PolicyDay>();
            EmployeeTimes = new HashSet<EmployeeTime>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PolicyDay> PolicyDays { get; set; }
        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
