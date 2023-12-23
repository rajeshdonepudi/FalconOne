using FalconOne.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class Department : ITrackableEntity
    {
        public Department()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public virtual Image ProfilePicture { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
