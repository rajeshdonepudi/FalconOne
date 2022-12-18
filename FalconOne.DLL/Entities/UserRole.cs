using Microsoft.AspNetCore.Identity;

namespace FalconOne.DAL.Entities
{
    public class UserRole : IdentityRole<Guid>
    {
        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
