namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public List<CartItemViewModel>? Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(i => i.Cost) ?? 0;
            }
        }
        public int Amount
        {
            get
            {
                return Items?.Sum(i => i?.Amount) ?? 0;
            }
        }
    }
}