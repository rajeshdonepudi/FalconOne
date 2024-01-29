namespace FalconOne.Models.Dtos.Common
{
    public record PagedListDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public object Records { get; set; }
    }
}
