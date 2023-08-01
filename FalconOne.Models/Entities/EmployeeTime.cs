using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class EmployeeTime
    {
        [Key]
        public Guid Id { get; set; }
        public Guid WeeklyOffPolicyId { get; set; }
        public Guid LeavePlanId { get; set; }
        public Guid HolidayCalenderId { get; set; }
        public Guid AttendanceNumber { get; set; }
        public Guid AttendanceCaptureSchemeId { get; set; }
        public Guid AttendanceTrackingPolicyId { get; set; }
        public Guid ShiftWeeklyOffRuleId { get; set; }
        public Guid ShiftAllowancePolicyId { get; set; }
        public Guid OverTimePolicyId { get; set; }
        public Guid EmployeeShiftId { get; set; }
        public virtual WeekOffPolicy WeekOffPolicy { get; set; }
        public virtual OverTimePolicy OverTimePolicy { get; set; }
        public virtual EmployeeShift EmployeeShift { get; set; }
        public virtual AttendanceTrackingPolicy AttendanceTrackingPolicy { get; set; }
        public virtual HolidayCalendar HolidayCalendar { get; set; }
        public virtual ShiftWeeklyOffRule ShiftWeeklyOffRule { get; set; }
        public virtual AttendanceCaptureScheme AttendanceCaptureScheme { get; set; }
        public virtual ShiftAllowancePolicy ShiftAllowancePolicy { get; set; }
        public virtual LeavePlan LeavePlan { get; set; }
    }
}
