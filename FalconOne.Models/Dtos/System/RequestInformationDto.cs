namespace FalconOne.Models.Dtos.System
{
    public record RequestInformationDto
    {
        public required string IP { get; set; }
        public required string UserAgent { get; set; }
        public required string TraceIdentifier { get; set; }
        public required string ResourceCode { get; set; }
        public required string Controller { get; set; }
        public required string Method { get; set; }
        public required string Action { get; set; }
        public required string Host { get; set; }
        public required string Path { get; set; }
        public required string Protocol { get; set; }
        public required int Port { get; set; }
        public required string Scheme { get; set; }
        public required DateTime RecordedOn { get; set; }
        public Guid? TenantId { get; set; }
    }
}
