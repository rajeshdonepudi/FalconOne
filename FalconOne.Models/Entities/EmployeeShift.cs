using FalconOne.Enumerations.Employee;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class EmployeeShift
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public int ShiftDuration { get; set; }
        public ShiftTypeEnum ShiftType { get; set; }
        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
