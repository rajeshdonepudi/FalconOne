using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class Department : MultiTenantEntity
    {
        public Department()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
            Posts = new HashSet<Post>();
            DepartmentLocations = new HashSet<DepartmentLocation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public virtual Image ProfilePicture { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<DepartmentLocation> DepartmentLocations { get; set; }
    }
}
