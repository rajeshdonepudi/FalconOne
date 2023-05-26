using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class Department : MultiTenantEntity
    {
        public Department()
        {
            Users = new HashSet<User>();
            Posts = new HashSet<Post>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public virtual Image ProfilePicture { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
