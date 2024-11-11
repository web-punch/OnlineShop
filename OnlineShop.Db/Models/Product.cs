
namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; }
        public List<string> ImagesPaths { get; set; } = new List<string>();
        public int ActiveIndexImagePath {  get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<Favorites>? Favorites { get; set; }
    }
}
