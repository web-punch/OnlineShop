namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        public OrderInfo Info { get; set; }
        public List<CartItem> Items { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;
    }
}
