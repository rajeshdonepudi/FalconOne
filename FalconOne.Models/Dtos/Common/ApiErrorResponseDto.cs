namespace FalconOne.Models.DTOs.Common
{
    public record ApiErrorResponseDto
    {
        public required string Message { get; set; }
    }
}
