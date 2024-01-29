using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Security
{
    public record AddClaimToRoleDto
    {
        [Required]
        public string RoleId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
