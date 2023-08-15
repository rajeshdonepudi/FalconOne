using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddToRoleDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }

    public class UserManagementDashboardInfo
    {
        public long TotalUsers { get; set; }
        public long ActiveUsers { get; set; }
        public long DeactivatedUsers { get; set; }
        public long VerifiedUsers { get; set; }
        public long UnVerifiedUsers { get; set; }
        public long LockedUsers { get; set; }
    }
}
