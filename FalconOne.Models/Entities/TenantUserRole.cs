using FalconOne.Models.Contracts;
using FalconOne.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    [EntityTypeConfiguration(typeof(TenantUserRoleConfiguration))]
    public class TenantUserRole : ISoftDeletable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid TenantUserId { get; set; }
        public virtual TenantUser TenantUser { get; set; }

        public Guid SecurityRoleId { get; set; }
        public virtual SecurityRole SecurityRole { get; set; }

        public bool IsDeleted { get; set; }
    }
}
