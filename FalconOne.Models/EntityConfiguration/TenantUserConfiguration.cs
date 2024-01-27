using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalconOne.Models.EntityConfiguration
{
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasKey(tu => new { tu.TenantId, tu.UserId });

            builder.HasOne(tu => tu.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(tu => tu.TenantId);

            builder.HasOne(tu => tu.User)
                .WithMany(u => u.Tenants)
                .HasForeignKey(tu => tu.UserId);
        }
    }
}
