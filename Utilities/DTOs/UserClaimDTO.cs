using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class UserClaimDTO
    {
        public Guid ClaimId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
