using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DLL.Entities
{
    public class ApplicationClaim
    {
        public ApplicationClaim()
        {
            Navigations = new List<Navigation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Values { get; set; }
        public Guid? ApplicationPolicyId { get; set; }
        public virtual ApplicationPolicy ApplicationPolicy { get; set; }
        public virtual List<Navigation> Navigations { get; set; }
    }
}
