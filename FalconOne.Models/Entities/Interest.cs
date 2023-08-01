namespace FalconOne.Models.Entities
{
    public class Interest
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
        public Guid EmployeeSummaryId { get; set; }
        public virtual EmployeeSummary EmployeeSummary { get; set; }
    }
}
