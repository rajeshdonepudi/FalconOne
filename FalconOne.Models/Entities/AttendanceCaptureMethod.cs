using FalconOne.Enumerations.Employee;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class AttendanceCaptureMethod
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// The name or title of the attendance capture scheme
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// A detailed description or summary of the attendance capture scheme
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The type of the attendance capture method, such as biometric, time clock, mobile app, etc.
        /// </summary>
        [Required]
        public AttendanceCaptureMethodTypeEnum MethodType { get; set; }
        public Guid AttendanceCaptureSchemeId { get; set; }
        public virtual AttendanceCaptureScheme AttendanceCaptureScheme { get; set; }
    }
}
