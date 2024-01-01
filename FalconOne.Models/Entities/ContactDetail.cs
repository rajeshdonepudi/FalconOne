using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class ContactDetail : ITrackableEntity
    {
        public Guid Id { get; set; }
        public string PersonalEmail { get; set; }
        public string WorkEmail { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string ResidencePhone { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
