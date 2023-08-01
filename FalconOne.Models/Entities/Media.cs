using FalconOne.Enumerations.Employee;

namespace FalconOne.Models.Entities
{
    public class Media
    {
        public Media()
        {
            Photos = new HashSet<Image>();
        }
        public Guid Id { get; set; }
        public string Content { get; set; }
        public MediaTypeEnum MediaType { get; set; }
        public Guid ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
        public virtual ICollection<Image> Photos { get; set; }
    }
}
