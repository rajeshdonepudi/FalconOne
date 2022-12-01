using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DLL.Entities
{
    public class ApplicationClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClaimId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid? ApplicationPolicyId { get; set; }
        public virtual ApplicationPolicy ApplicationPolicy { get; set; }
    }
}
