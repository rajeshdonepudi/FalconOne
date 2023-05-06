using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DAL.Entities
{

    public class ApplicationClaim : MultiTenantEntity
    {
        public ApplicationClaim()
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
        public virtual ApplicationPolicy ApplicationPolicy { get; set; }
        public virtual List<Navigation> Navigations { get; set; }
    }
}
