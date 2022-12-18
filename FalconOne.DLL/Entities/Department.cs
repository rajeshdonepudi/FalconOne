using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DAL.Entities
{
    public class Department : MultiTenantEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Post> Posts { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
