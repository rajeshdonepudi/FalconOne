namespace FalconOne.Models.Contracts
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
    }
    public interface ITrackableEntity
    {
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
