using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Security
{
    public record AddClaimToUserDto
    {
        [Required]
        public string UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
