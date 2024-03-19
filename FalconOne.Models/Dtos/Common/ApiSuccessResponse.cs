namespace FalconOne.Models.DTOs.Common
{
    public record ApiSuccessResponse
    {
        public required string Message { get; set; }
        public int StatusCode { get; set; }
        public required object Data { get; set; }
    }
}
