using FalconOne.Enumerations.Employee;
using FalconOne.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class EmployeeShift : ITrackableEntity
    {
        public EmployeeShift()
        {
            EmployeeTimes = new HashSet<EmployeeTime>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public int ShiftDuration { get; set; }
        public ShiftTypeEnum ShiftType { get; set; }
        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
