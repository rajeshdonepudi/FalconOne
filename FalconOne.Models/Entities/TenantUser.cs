using FalconOne.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.Models.Entities
{
    [EntityTypeConfiguration(typeof(TenantUserConfiguration))]
    public class TenantUser
    {
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
