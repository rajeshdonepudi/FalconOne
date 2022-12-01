using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.DLL.Entities
{
    public class ApplicationPolicy
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
