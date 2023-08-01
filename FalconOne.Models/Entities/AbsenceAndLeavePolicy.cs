using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class AbsenceAndLeavePolicy
    {
        public AbsenceAndLeavePolicy()
        {
            AdditionalLeaveTypes = new HashSet<LeaveType>();
        }

        [Key]
        public Guid Id { get; set; }
        public int MaximumVacationDaysPerYear { get; set; }
        public int MaximumSickLeaveDaysPerYear { get; set; }
        public int MaximumPersonalLeaveDaysPerYear { get; set; }
        public int MaximumUnpaidLeaveDaysPerYear { get; set; }
        public virtual ICollection<LeaveType> AdditionalLeaveTypes { get; set; }
    }
}
