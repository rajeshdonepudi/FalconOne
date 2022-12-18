using System.ComponentModel.DataAnnotations;

namespace FalconOne.DAL.Entities
{
    public class AttendanceLog
    {
        public AttendanceLog()
        {
            TimeLogs = new HashSet<TimeLog>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int DayType { get; set; }

        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public ICollection<TimeLog> TimeLogs { get; set; }
    }
}
