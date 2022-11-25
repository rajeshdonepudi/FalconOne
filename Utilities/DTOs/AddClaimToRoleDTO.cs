using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Utilities.DTOs
{
    public class AddClaimToRoleDTO
    {
        [Required]
        public string RoleId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
