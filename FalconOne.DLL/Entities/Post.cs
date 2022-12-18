using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DAL.Entities
{
    public class Post : MultiTenantEntity
    {
        public Post()
        {
            Reactions = new HashSet<Reaction>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public Employee PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
