using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class OrderInfo
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string? Comment { get; set; }
    }
}
