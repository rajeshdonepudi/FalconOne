using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs.Security
{
    public record AddClaimsToUserDto
    {
        [Required]
        public string UserId { get; set; }
        public IEnumerable<Guid> Claims { get; set; }
    }
}
