using FalconOne.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class Tenant : ITrackableEntity
    {
        public Tenant()
        {
            Users = new HashSet<TenantUser>();
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
        public virtual ICollection<TenantUser> Users { get; set; }
    }
}
