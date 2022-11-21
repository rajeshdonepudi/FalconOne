using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Utilities.DTOs
{
    public class AddClaimToUserDTO
    {
        [Required]
        public string UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
