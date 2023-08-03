using FalconOne.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace FalconOne.Models.EntityConfiguration
{
    public class EmployeeTimeConfiguration : IEntityTypeConfiguration<EmployeeTime>
    {
        public void Configure(EntityTypeBuilder<EmployeeTime> builder)
        {
            builder.HasOne(e => e.ShiftWeeklyOffRule)
                   .WithMany(s => s.EmployeeTimes)
                   .HasForeignKey(e => e.ShiftWeeklyOffRuleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class TenantLocationConfiguration : IEntityTypeConfiguration<TenantLocation>
    {
        public void Configure(EntityTypeBuilder<TenantLocation> builder)
        {
            builder.HasKey(tl => new { tl.TenantId, tl.LocationId });

            builder.HasOne(tl => tl.Tenant)
                   .WithMany(t => t.TenantLocations)
                   .HasForeignKey(t => t.TenantId);

            builder.HasOne(tl => tl.Location)
                .WithMany(tl => tl.TenantLocations)
                .HasForeignKey(t => t.LocationId);
        }
    }
    public class DepartmentEmployeeConfiguration : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            builder.HasOne(ed => ed.Department)
                   .WithMany(d => d.EmployeeDepartments)
                   .HasForeignKey(ed => ed.DepartmentId);

            builder.HasOne(ed => ed.Employee)
                   .WithMany(l => l.EmployeeDepartments)
                   .HasForeignKey(ed => ed.EmployeeId);
        }
    }
    public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
    {
        public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
        {
            builder.HasKey(dl => new { dl.DepartmentId, dl.LocationId });

            builder.HasOne(dl => dl.Department)
                   .WithMany(d => d.DepartmentLocations)
                   .HasForeignKey(dl => dl.DepartmentId);

            builder.HasOne(dl => dl.Location)
                   .WithMany(l => l.DepartmentLocations)
                   .HasForeignKey(dl => dl.LocationId);
        }
    }
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasKey(tu => new { tu.TenantId, tu.UserId });

            builder.HasOne(tu => tu.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(tu => tu.TenantId);

            builder.HasOne(tu => tu.User)
                .WithMany(u => u.TenantUsers)
                .HasForeignKey(tu => tu.UserId);
        }
    }
}
