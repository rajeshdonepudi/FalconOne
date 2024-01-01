namespace FalconOne.Models.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
