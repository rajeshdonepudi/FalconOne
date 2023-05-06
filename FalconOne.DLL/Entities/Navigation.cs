using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DAL.Entities
{
    public class Navigation : MultiTenantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public Guid ApplicationClaimId { get; set; }
        public virtual ApplicationClaim ApplicationClaim { get; set; }
    }
}
