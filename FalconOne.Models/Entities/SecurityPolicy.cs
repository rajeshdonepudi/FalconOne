using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class SecurityPolicy : MultiTenantEntity
    {
        public SecurityPolicy()
        {
            PolicyClaims = new List<SecurityClaim>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<SecurityClaim> PolicyClaims { get; set; }
    }
}
