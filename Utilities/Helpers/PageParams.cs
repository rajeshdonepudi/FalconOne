namespace FalconOne.Helpers.Helpers
{
    public class PageParams
    {
        const int maxPageSize = 50;
        private int _pageIndex = 0;

        public int Page
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }
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
