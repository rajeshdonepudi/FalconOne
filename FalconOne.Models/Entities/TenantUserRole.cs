using FalconOne.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    [EntityTypeConfiguration(typeof(TenantUserRoleConfiguration))]
    public class TenantUserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid TenantUserId { get; set; }
        public virtual TenantUser TenantUser { get; set; }

        public Guid SecurityRoleId { get; set; }
        public virtual SecurityRole SecurityRole { get; set; }
    }
}
