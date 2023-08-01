namespace FalconOne.Models.Entities
{
    public class Metadata
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid MetadataGroupId { get; set; }
        public virtual MetadataGroup MetadataGroup { get; set; }
    }
}
