using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class ApplicationPolicy : MultiTenantEntity
    {
        public ApplicationPolicy()
        {
            PolicyClaims = new List<ApplicationClaim>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<ApplicationClaim> PolicyClaims { get; set; }
    }
}
