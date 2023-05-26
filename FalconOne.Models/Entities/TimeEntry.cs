using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class TimeEntry
    {
        public TimeEntry()
        {
            TimeLogs = new HashSet<TimeLog>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int DayType { get; set; }

        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<TimeLog> TimeLogs { get; set; }
    }
}
