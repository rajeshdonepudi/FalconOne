using FalconOne.Models.Entities;

namespace FalconOne.Models.DTOs
{
    public record DepartmentDto : BaseDto
    {
        public DepartmentDto()
        {

        }

        public DepartmentDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
