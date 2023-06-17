namespace FalconOne.Models.Contracts
{
    public interface ITrackableEntity
    {
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
