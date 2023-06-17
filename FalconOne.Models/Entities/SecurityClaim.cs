using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class SecurityClaim : MultiTenantEntity
    {
        public SecurityClaim()
        {
            Navigations = new List<Navigation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public Guid? ApplicationPolicyId { get; set; }
        public virtual SecurityPolicy ApplicationPolicy { get; set; }
        public virtual List<Navigation> Navigations { get; set; }
    }
}
