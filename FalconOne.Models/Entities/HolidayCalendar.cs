using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class HolidayCalendar
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<Holiday> Holidays { get; set; }

        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
