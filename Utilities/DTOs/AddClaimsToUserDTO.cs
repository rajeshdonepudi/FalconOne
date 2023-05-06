using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class AddClaimsToUserDTO
    {
        [Required]
        public string UserId { get; set; }
        public IEnumerable<Guid> Claims { get; set; }
    }
}
