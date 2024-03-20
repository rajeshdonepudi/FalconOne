using FalconOne.Enumerations.Employee;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FalconOne.Models.Entities
{
    public class User : IdentityUser<Guid>, ITrackableEntity, ISoftDeletable, IEquatable<User>, ICloneable
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public bool IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ResourceAlias { get; private set; }

        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public virtual Image? ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool PhysicallyChallenged { get; set; }

        public EmployeeGenderEnum Gender { get; set; } = EmployeeGenderEnum.NotSpecified;
        public MaritalStatusEnum MaritalStatus { get; set; } = MaritalStatusEnum.NotSpecified;
        public BloodGroupTypeEnum BloodGroup { get; set; } = BloodGroupTypeEnum.NotSpecified;

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<TenantUser> Tenants { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCloned { get; set; }
        public DateTime DeletedOn { get; set; }

        public object Clone()
        {
            var user = new User();

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.MiddleName = MiddleName;
            user.ProfilePicture = ProfilePicture;
            user.DateOfBirth = DateOfBirth;
            user.PhysicallyChallenged = PhysicallyChallenged;
            user.Gender = Gender;
            user.MaritalStatus = MaritalStatus;
            user.IsDeleted = IsDeleted;
            user.BloodGroup = BloodGroup;
            user.IsDeleted = IsDeleted;
            user.IsActive = IsActive;
            user.Tenants = Tenants;
            user.IsCloned = true;
            user.Email = CloneHelper.GetCloneEmail(Email);

            return user;
        }

        public bool Equals(User? other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                return hash;
            }
        }
    }
}
