using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class MultiTenantEntity : IMultiTenantEntity
    {
        private DateTime createdOn;

        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn
        {
            get => createdOn;
            set => createdOn = DateTime.UtcNow;
        }
    }
}
