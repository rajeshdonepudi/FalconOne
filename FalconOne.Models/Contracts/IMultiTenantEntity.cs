using FalconOne.Models.Entities;

namespace FalconOne.Models.Contracts
{
    public interface IMultiTenantEntity : ITrackableEntity
    {
        Guid? TenantId { get; set; }
        Tenant Tenant { get; set; }
    }
}
