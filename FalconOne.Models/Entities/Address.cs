using FalconOne.Enumerations.Employee;

namespace FalconOne.Models.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public AddressTypeEnum AddressType { get; set; }
        public LocationTypeEnum LocationType { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid CountryId { get; set; }    
        public virtual Employee Employee { get; set; }
        public virtual Country Country { get; set; }
    }
}
