using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class Holiday
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string HolidayName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Guid CalendarId { get; set; }
        public virtual HolidayCalendar HolidayCalendar { get; set; }
    }
}
