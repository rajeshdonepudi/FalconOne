using FalconOne.Models.Contracts;
using FalconOne.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    [EntityTypeConfiguration(typeof(TenantUserConfiguration))]
    public class TenantUser : ISoftDeletable
    {
        public TenantUser()
        {
            TenantUserRoles = new HashSet<TenantUserRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }
        public virtual ICollection<TenantUserRole> TenantUserRoles { get; set; }
    }
}
