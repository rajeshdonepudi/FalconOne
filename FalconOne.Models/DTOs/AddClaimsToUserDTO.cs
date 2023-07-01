using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddClaimsToUserDto
    {
        [Required]
        public string UserId { get; set; }
        public IEnumerable<Guid> Claims { get; set; }
    }
}
