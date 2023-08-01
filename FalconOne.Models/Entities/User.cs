using FalconOne.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class User : IdentityUser<Guid>, ITrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ResourceId { get; set; }
        public User()
        {
            RefreshTokens = new List<RefreshToken>();
        }

        public List<RefreshToken> RefreshTokens { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public virtual Image? ProfilePicture { get; set; }
        public virtual ICollection<TenantUser> Tenants { get; set; }
        public bool OwnsToken(string token)
        {
            return RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
