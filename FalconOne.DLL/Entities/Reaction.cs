namespace FalconOne.DAL.Entities
{

    public class Reaction : MultiTenantEntity
    {
        public Guid Id { get; set; }
        public int ReactionType { get; set; }
        public Employee ReactedBy { get; set; }
        public DateTime ReactionOn { get; set; }
        public Guid? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
