using FalconOne.Enumerations.Employee;

namespace FalconOne.Models.Entities
{
    public class MetadataGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public MetadataGroupTypeClassificationEnum Classification { get; set; }
        public virtual ICollection<Metadata> Metadatas { get; set; }
    }
}
