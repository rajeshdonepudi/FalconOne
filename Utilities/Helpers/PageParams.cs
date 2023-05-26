namespace FalconOne.Helpers.Helpers
{
    public class PageParams
    {
        const int maxPageSize = 50;
        public int PageIndex { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }
    }
}
