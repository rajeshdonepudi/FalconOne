using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class TimeLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime In { get; set; }
        public DateTime Out { get; set; }
        public Guid? AttendanceLogId { get; set; }
        public virtual TimeEntry AttendanceLog { get; set; }
    }
}
