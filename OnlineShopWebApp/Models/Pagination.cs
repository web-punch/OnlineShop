namespace OnlineShopWebApp.Models
{
    public class Pagination
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int StartNumbering { get; set; }
        public int EndNumbering { get; set; }
        public bool HasPreviousPage
        {
            get
            {
                return PageNumber > 1;
            }
        }
        public bool HasNextPage
        {
            get
            {
                return PageNumber < TotalPages;
            }
        }

        public Pagination(int countItems, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(countItems / (double)pageSize);
        }
    }
}
