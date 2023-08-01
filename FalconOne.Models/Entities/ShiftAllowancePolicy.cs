using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class ShiftAllowancePolicy
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// The name or title of the shift allowance policy.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// A detailed description or summary of the shift allowance policy
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The amount of the allowance, either in a fixed currency value or percentage (based on the IsPercentage property
        /// </summary>
        [Required]
        public decimal AllowanceAmount { get; set; }
        /// <summary>
        ///  A flag indicating whether the allowance is a percentage of the shift or a fixed amount
        /// </summary>
        [Required]
        public bool IsPercentage { get; set; }
        /// <summary>
        ///  The date from which the policy becomes effective.
        /// </summary>
        [Required]
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// A collection of shifts associated with this shift allowance policy.
        /// </summary>
        public virtual ICollection<EmployeeShift> Shifts { get; set; }

        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
