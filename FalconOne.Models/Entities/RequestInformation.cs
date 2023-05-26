using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalconOne.Models.Entities
{
    public class RequestInformation : MultiTenantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string IP { get; set; }
        public string TraceIdentifier { get; set; }
        public string ResourceCode { get; set; }
        public string UserAgent { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string Host { get; set; }
        public string Protocol { get; set; }
        public int Port { get; set; }
        public string Scheme { get; set; }
        public DateTime RecordedOn { get; set; }
    }
}
