using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? UserName { get; set; }
        public OrderInfoViewModel? Info { get; set; }
        public List<CartItemViewModel>? Items { get; set; }
        public OrderStatus? Status { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
