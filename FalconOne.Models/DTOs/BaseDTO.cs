namespace FalconOne.Models.DTOs
{
    public record BaseDTO
    {
        public string Message { get; set; }
        public List<BusinessError> Errors { get; set; }
    }
}
