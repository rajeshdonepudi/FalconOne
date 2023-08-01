using FalconOne.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class NewPostDto
    {
        public string? Content { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TenantId { get; set; }
        public Guid PostedBy { get; set; }
        public List<ImageDto>? Images { get; set; }
        public DateTime PostedOn { get; set; }
    }

    public class ImageDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public Guid? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
