namespace FalconOne.Models.DTOs
{
    public class RequestInformationDTO
    {
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string TraceIdentifier { get; set; }
        public string ResourceCode { get; set; }
        public string Controller { get; set; }
        public string Method { get; set; }
        public string Action { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string Protocol { get; set; }
        public int Port { get; set; }
        public string Scheme { get; set; }
        public DateTime RecordedOn { get; set; }
        public Guid? TenantId { get; set; }
    }
}
