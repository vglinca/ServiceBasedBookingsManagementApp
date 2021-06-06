namespace OnlineBookingAggregatorApp.Infrastructure.Pagination
{
    public class PagedRequest
    {
        private const int MaxPageSize = 20;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        public int PageNumber { get; set; } = 1;
        public string Filter { get; set; }
        public string FilterFields { get; set; }
        public string OrderBy { get; set; }
        public bool Ascending { get; set; } = false;
    }
}