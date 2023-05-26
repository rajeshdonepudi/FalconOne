using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddClaimsToUserDTO
    {
        [Required]
        public string UserId { get; set; }
        public IEnumerable<Guid> Claims { get; set; }
    }
}
