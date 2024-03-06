using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalconOne.Models.EntityConfiguration
{
    public class TenantUserRoleConfiguration : IEntityTypeConfiguration<TenantUserRole>
    {
        public void Configure(EntityTypeBuilder<TenantUserRole> builder)
        {
            builder.HasKey(tu => tu.Id);

            builder.HasOne(tur => tur.TenantUser)
                .WithMany(tu => tu.TenantUserRoles)
                .HasForeignKey(tur => tur.TenantUserId);

            builder.HasOne(tur => tur.SecurityRole)
                .WithMany(sr => sr.TenantUserRoles)
                .HasForeignKey(tur => tur.SecurityRoleId);
        }
    }
}
