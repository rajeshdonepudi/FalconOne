using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FalconOne.DAL.Entities
{
    public class UserRole : IdentityRole<Guid>, IMultiTenantEntity
    {
        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
