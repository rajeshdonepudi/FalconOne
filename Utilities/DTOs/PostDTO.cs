namespace Utilities.DTOs
{
    public class PostDTO
    {
        public string Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TenantId { get; set; }
        public UserDTO PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
