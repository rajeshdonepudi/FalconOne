using FalconOne.Models.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FalconOne.Models.Entities
{
    public class SecurityRole : IdentityRole<Guid>, ITrackableEntity
    {
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
