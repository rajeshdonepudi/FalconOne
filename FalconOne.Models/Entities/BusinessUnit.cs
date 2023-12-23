using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class BusinessUnit : ITrackableEntity
    {
        public BusinessUnit()
        {
            Locations = new HashSet<Location>();
        }

        public Guid Id { get; set; }
        public required string  Name { get; set; }     
        public Guid LegalEntityId { get; set; }
        public virtual LegalEntity LegalEntity { get; set; }
        public ICollection<Location> Locations { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
