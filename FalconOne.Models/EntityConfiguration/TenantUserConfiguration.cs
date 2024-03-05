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

    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasKey(tu => tu.Id);

            builder.HasOne(tu => tu.Tenant)
                   .WithMany(t => t.Users)
                   .HasForeignKey(tu => tu.TenantId);

            builder.HasOne(tu => tu.User)
                   .WithMany(u => u.Tenants)
                   .HasForeignKey(tu => tu.UserId);
        }
    }
}
