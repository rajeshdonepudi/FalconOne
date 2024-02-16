namespace FalconOne.Helpers.Helpers
{
    public class PagedList<T>
    {
        public List<T> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        public PagedList(List<T> items, PageParams model, int totalItems)
        {
            PageIndex = model.PageIndex;
            PageSize = model.PageSize;
            TotalItems = totalItems;
            Items = items;
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
                return (PageIndex + 1) * PageSize < TotalItems;
            }
        }
    }
}
