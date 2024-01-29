using FalconOne.Models.Entities;

namespace FalconOne.Models.DTOs.Users
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
            UserName = user.UserName!;
            Email = user.Email!;
            Phone = user.PhoneNumber!;
            EmailConfirmed = user.EmailConfirmed;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            TwoFactorEnabled = user.TwoFactorEnabled;
            LockoutEnabled = user.LockoutEnabled;
            CreatedOn = user.CreatedOn;
        }
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
