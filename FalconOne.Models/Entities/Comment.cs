namespace FalconOne.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public User CommentedBy { get; set; }
        public DateTime CommentedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
