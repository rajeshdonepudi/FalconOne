namespace Utilities.DTOs
{
    public class NewPostDTO
    {
        public string Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TenantId { get; set; }
        public Guid PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
