using FalconOne.DAL.Interfaces;

namespace FalconOne.DAL.Entities
{
    public class MultiTenantEntity : IMultiTenantEntity, ITrackableEntity
    {
        private DateTime createdOn;

        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get => createdOn; set => createdOn = DateTime.UtcNow; }
    }
}
