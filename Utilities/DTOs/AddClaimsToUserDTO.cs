using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Utilities.DTOs
{
    public class AddClaimsToUserDTO
    {
        [Required]
        public string UserId { get; set; }
        public IEnumerable<Guid> Claims { get; set; }
    }
}
