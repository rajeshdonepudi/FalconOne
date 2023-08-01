using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class Post : MultiTenantEntity
    {
        public Post()
        {
            Reactions = new HashSet<Reaction>();
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
            TaggedEmployees = new HashSet<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid PostedById { get; set; }
        public DateTime PostedOn { get; set; }
        public virtual Employee PostedBy { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Employee> TaggedEmployees { get; set; }
    }
}
