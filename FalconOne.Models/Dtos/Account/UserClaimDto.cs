using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Account
{
    public class UserClaimDto
    {
        [Required]
        public required string Type { get; set; }
        [Required]
        public required string Value { get; set; }
        public string? PolicyId { get; set; }
        public required string Description { get; set; }
    }
}
