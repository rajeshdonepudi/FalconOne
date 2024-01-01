using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class Country : ITrackableEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string TwoCharCountryCode { get; set; }
        public required string ThreeCharCountryCode { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
