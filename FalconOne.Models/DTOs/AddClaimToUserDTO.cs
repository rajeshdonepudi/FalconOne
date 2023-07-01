using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddClaimToUserDto

    {
        [Required]
        public string UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
