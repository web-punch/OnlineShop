namespace OnlineShopWebApp.Models
{
    public class ProductsPaginationViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public Pagination Pagination { get; set; }
        public ProductsPaginationViewModel(List<ProductViewModel> products, Pagination pagination)
        {
            Products = products;
            Pagination = pagination;
        }
    }
}
