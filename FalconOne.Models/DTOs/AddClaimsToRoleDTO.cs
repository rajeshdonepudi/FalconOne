using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FalconOne.Models.DTOs
{
    public class AddClaimsToRoleDto
    {
        [Required]
        public string RoleId { get; set; }
        public List<Claim> Claim { get; set; }
    }
}
