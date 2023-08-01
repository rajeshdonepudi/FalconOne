using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class LeavePlan
    {
        [Key]
        public Guid LeavePlanId { get; set; }

        // The name or description of the leave plan.
        [Required]
        public string Name { get; set; }

        // The total number of leave days allocated to the employee for this plan.
        [Required]
        public int TotalLeaveDays { get; set; }

        // The number of leave days remaining for the employee within this plan.
        [Required]
        public int RemainingLeaveDays { get; set; }

        // The start date of the leave plan's validity period.
        [Required]
        public DateTime ValidFrom { get; set; }

        // The end date of the leave plan's validity period.
        [Required]
        public DateTime ValidTo { get; set; }
        public virtual ICollection<EmployeeTime> EmployeeTimes { get; set; }
    }
}
