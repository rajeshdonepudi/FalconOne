namespace FalconOne.Models.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string TwoCharCountryCode { get; set; }
        public required string ThreeCharCountryCode { get; set; }
    }
}
