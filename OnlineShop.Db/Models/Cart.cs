﻿namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}