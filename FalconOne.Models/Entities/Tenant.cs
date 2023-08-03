using FalconOne.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class Tenant : ITrackableEntity
    {
        public Tenant()
        {
            Posts = new HashSet<Post>();
            Departments = new HashSet<Department>();
            Users = new HashSet<TenantUser>();
            Locations = new HashSet<Location>();
            BusinessUnits = new HashSet<BusinessUnit>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string AccountAlias { get; private set; }
        public string Host { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Image? ProfilePicture { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<TenantUser> Users { get; set; }
        public virtual ICollection<TenantLocation> TenantLocations { get; set; }
        public virtual ICollection<BusinessUnit> BusinessUnits { get; set; }
        public virtual ICollection<Designation> Designations { get; set; }
    }
}
