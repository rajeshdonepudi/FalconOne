using FalconOne.DAL.Entities;

namespace FalconOne.DAL.Interfaces
{
    public interface IMultiTenantEntity : ITrackableEntity
    {
        Guid? TenantId { get; set; }
        Tenant Tenant { get; set; }
    }
}
