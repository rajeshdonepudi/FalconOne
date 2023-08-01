using FalconOne.Enumerations.Employee;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class OverTimePolicy
    {
        /// <summary>
        ///  A unique identifier for the overtime policy.
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// A descriptive name or title for the overtime policy.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A detailed explanation or summary of the overtime policy.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  The criteria or condition that determines when overtime is applicable, such as exceeding a certain number of hours worked in a day or week.
        /// </summary>
        public TimeSpan OverTimeThreshold { get; set; }
        /// <summary>
        /// The rate at which overtime hours are compensated, which may be different from the regular hourly rate.
        /// </summary>
        public decimal OverTimeRate { get; set; }
        /// <summary>
        ///  The method used to calculate overtime, such as weekly, daily, or both.
        /// </summary>
        public OvertimeCalculationMethodEnum OvertimeCalculationMethod { get; set; }
        /// <summary>
        /// The process for requesting and obtaining authorization for overtime work, including any required approvals or documentation.
        /// </summary>
        public Guid OverTimeAuthorizationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual OverTimeAuthorization OverTimeAuthorization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastReviewDate { get; set; }

        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }

    }
}
