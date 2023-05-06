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
            Images = new HashSet<Image>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public User PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
