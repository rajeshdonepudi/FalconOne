using FalconOne.Enumerations.Employee;
using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class Address : ITrackableEntity
    {
        public Guid Id { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public AddressTypeEnum AddressType { get; set; } = AddressTypeEnum.NotSpecified;
        public LocationTypeEnum LocationType { get; set; } = LocationTypeEnum.NotSpecified;
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public virtual User User { get; set; }
        public virtual Country Country { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
