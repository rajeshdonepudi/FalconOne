using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class AttendanceCaptureScheme
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// The name or title of the attendance capture scheme
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// A detailed description or summary of the attendance capture scheme.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// A flag indicating whether the scheme requires employees to track their attendance time, such as clocking in and out
        /// </summary>
        [Required]
        public bool RequiresTimeTracking { get; set; }
        /// <summary>
        /// A flag indicating whether the attendance recorded by employees requires approval by supervisors or administrators
        /// </summary>
        [Required]
        public bool RequiresAttendanceApproval { get; set; }
        /// <summary>
        /// A collection of attendance capture methods associated with this scheme
        /// </summary>
        public virtual ICollection<AttendanceCaptureMethod> CaptureMethods { get; set; }

        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
