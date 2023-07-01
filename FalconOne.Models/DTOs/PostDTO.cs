namespace FalconOne.Models.DTOs
{
    public class PostDto
    {
        public string Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TenantId { get; set; }
        public UserDto PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
