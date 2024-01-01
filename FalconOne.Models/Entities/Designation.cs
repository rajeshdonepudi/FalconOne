using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class Designation : ITrackableEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
