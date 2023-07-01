namespace FalconOne.Models.DTOs
{
    public record BaseDto
    {
        public string Message { get; set; }
        public List<BusinessError> Errors { get; set; }
    }
}
