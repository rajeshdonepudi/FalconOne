namespace FalconOne.Models.DTOs
{
    public class PagedListDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public object Records { get; set; }
    }
    public class VerifyEmailDTO
    {
        public string UserId { get; set; }
        public string EmailConfirmationToken { get; set; }
    }
}
