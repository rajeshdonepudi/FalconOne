using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class TenantLocation
    {
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
    public class EmployeeDepartment
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class DepartmentLocation
    {
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public class Location
    {
        public Location()
        {
            DepartmentLocations = new HashSet<DepartmentLocation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public virtual ICollection<DepartmentLocation> DepartmentLocations { get; set; }
        public virtual ICollection<TenantLocation> TenantLocations { get; set; }
    }
}
