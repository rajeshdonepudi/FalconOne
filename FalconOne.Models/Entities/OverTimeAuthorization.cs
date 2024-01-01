namespace FalconOne.Models.Entities
{
    public class OverTimeAuthorization
    {
        /// <summary>
        /// a unique identifier for the authorization process.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// a boolean property that indicates whether the overtime request is approved or not.
        /// </summary>
        public bool IsApproved { get; set; }
        /// <summary>
        ///  stores any comments or notes provided by the approver.
        /// </summary>
        public string ApproverComments { get; set; }
        /// <summary>
        ///  store the timestamps of the overtime request.
        /// </summary>
        public DateTime RequestedOn { get; set; }
        /// <summary>
        ///  store the timestamps of the overtime request.
        /// </summary>
        public DateTime ApprovedOn { get; set; }
        /// <summary>
        /// capture the names or identifiers of the individuals involved in the request.
        /// </summary>
        public Guid RequestedById { get; set; }
        public virtual User RequestedBy { get; set; }
        /// <summary>
        /// capture the names or identifiers of the individuals involved in the approval processes.
        /// </summary>
        public Guid ApprovedById { get; set; }
        public virtual User ApprovedBy{ get; set; }
    }
}
