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
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public Image? ProfilePicture { get; set; }
    }
}
