using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.Entities
{
    public class LeaveType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
