namespace HotelListing.Core.Models
{
    public class RequestParams
    {
        const int minPageNumber = 1;
        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < minPageNumber) ? minPageNumber : value;
            }
        }
        const int maxPageSize = 50;
        const int minPageSize = 1;
        private int _pageSize;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            { 
                _pageSize = (value > maxPageSize) ? maxPageSize : (value < minPageSize ? minPageSize : value);
            }
        }
    }
}
