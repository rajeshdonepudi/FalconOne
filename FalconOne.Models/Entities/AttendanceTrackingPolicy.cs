using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class AttendanceTrackingPolicy
    {
        /// <summary>
        /// A unique identifier for the attendance tracking policy
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// A descriptive name or title for the attendance tracking policy.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A detailed explanation or summary of the attendance tracking policy.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The standard or expected number of work hours per day.
        /// </summary>
        public int WorkHours { get; set; }
        /// <summary>
        /// The allowable time duration for employees to arrive after their scheduled start time without being considered late.
        /// </summary>
        public TimeSpan GracePeriod { get; set; }
        /// <summary>
        /// The time duration after which an employee is considered late if they arrive after the scheduled start time plus the grace period.
        /// </summary>
        public TimeSpan LateArrivalThreshold { get; set; }
        /// <summary>
        /// The time duration before the scheduled end time at which an employee is considered to have left early.
        /// </summary>
        public TimeSpan EarlyDepartureThresHold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid BreakAndMealPeriodsId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RequiresTimeTracking { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RemoteWorkAllowed { get; set; }
        public virtual RemoteWorkEligibilityCriteria RemoteWorkEligibilityCriteria { get; set; }
        public virtual BreakAndMealPeriod BreakAndMealPeriods { get; set; }
        public virtual AbsenceAndLeavePolicy AbsenceAndLeavePolicies { get; set; }
        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
