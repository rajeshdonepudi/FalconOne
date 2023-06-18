namespace FalconOne.Helpers.Helpers
{
    public class PageParams
    {
        const int maxPageSize = 50;
        private int _pageIndex = 1;

        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value == default ? 1 : value;
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
