using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FalconOne.Models.Entities
{
    public class User : IdentityUser<Guid>, ITrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {
            RefreshTokens = new List<RefreshToken>();
            TimeEntries = new HashSet<TimeEntry>();
        }

        public List<RefreshToken> RefreshTokens { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Image? ProfilePicture { get; set; }
        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
        public bool OwnsToken(string token)
        {
            return RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
