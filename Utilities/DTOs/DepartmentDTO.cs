namespace Utilities.DTOs
{
    public class DepartmentDTO : BaseDTO
    {
        public string Name { get; set; }
        public ICollection<UserDTO> Users { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
    }
}
