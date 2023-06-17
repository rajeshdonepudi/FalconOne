namespace FalconOne.Helpers.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> source, long count, int index, int pageSize)
        {
            TotalCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source);
        }

        public long TotalCount
        {
            get; set;
        }

        public int PageIndex
        {
            get; set;
        }

        public int PageSize
        {
            get; set;
        }

        public bool IsPreviousPage
        {
            get
            {
                return PageIndex > 0;
            }
        }
        public bool IsNextPage
        {
            get
            {
                return PageIndex * PageSize <= TotalCount;
            }
        }
    }
}
