using FalconOne.Models.Entities;

namespace FalconOne.Models.DTOs
{
    public class UserDto
    {
        public UserDto()
        {

        }
        public UserDto(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            EmailConfirmed = user.EmailConfirmed;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            TwoFactorEnabled = user.TwoFactorEnabled;
            LockoutEnabled = user.LockoutEnabled;
            CreatedOn = user.CreatedOn;
            Tenants = user.Tenants.Any() ? user.Tenants.Select(x => x.UserId).ToList() : new List<Guid> { };
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Guid> Tenants { get; set; }
    }
}
