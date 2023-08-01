using FalconOne.Enumerations.Employee;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class ShiftWeeklyOffRule
    {
        public ShiftWeeklyOffRule()
        {
            EmployeeTimes = new HashSet<EmployeeTime>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DayOfWeekEnum WeeklyOffDay { get; set; }

        public int ShiftDurationInHours { get; set; }

        public Guid EmployeeShiftId { get; set; }
        public virtual EmployeeShift EmployeeShift { get; set; }
        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
