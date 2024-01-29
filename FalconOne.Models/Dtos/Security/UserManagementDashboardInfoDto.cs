namespace FalconOne.Models.DTOs.Security
{
    public record UserManagementDashboardInfoDto
    {
        public long TotalUsers { get; set; }
        public long ActiveUsers { get; set; }
        public long DeactivatedUsers { get; set; }
        public long VerifiedUsers { get; set; }
        public long UnVerifiedUsers { get; set; }
        public long LockedUsers { get; set; }
    }
}
