namespace FalconOne.Models.Entities
{
    public class ContactDetail
    {
        public Guid Id { get; set; }
        public string PersonalEmail { get; set; }
        public string WorkEmail { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string ResidencePhone { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
