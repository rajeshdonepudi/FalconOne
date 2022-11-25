using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Utilities.DTOs
{
    public class AddClaimsToRoleDTO
    {
        [Required]
        public string RoleId { get; set; }
        public List<Claim> Claim { get; set; }
    }
}
