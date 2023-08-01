using FalconOne.Enumerations.Employee;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class PolicyDay
    {
        public PolicyDay()
        {
            WeekOffPolicies = new HashSet<WeekOffPolicy>();
        }
        [Key]
        public Guid Id { get; set; }
        public WeekDayEnum Day { get; set; }
        public virtual ICollection<WeekOffPolicy> WeekOffPolicies { get; set; }
    }
}
