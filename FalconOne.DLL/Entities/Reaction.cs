namespace FalconOne.DAL.Entities
{

    public class Reaction
    {
        public Guid Id { get; set; }
        public int ReactionType { get; set; }
        public User ReactedBy { get; set; }
        public DateTime ReactionOn { get; set; }
        public Guid? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
