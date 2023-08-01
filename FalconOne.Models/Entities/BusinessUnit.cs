namespace FalconOne.Models.Entities
{
    public class BusinessUnit
    {
        public Guid Id { get; set; }
        public required string  Name { get; set; }
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
