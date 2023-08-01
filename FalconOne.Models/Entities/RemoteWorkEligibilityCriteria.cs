using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class RemoteWorkEligibilityCriteria
    {
        [Key]
        public int CriteriaId { get; set; }

        [Required]
        public string CriteriaName { get; set; }

        public string Description { get; set; }

        public bool RequiresApproval { get; set; }
    }
}
