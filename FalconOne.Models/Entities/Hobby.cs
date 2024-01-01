using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class Hobby : ITrackableEntity
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
        public Guid EmployeeSummaryId { get; set; }
        public virtual EmployeeSummary EmployeeSummary { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
