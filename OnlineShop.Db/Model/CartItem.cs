using System;

namespace OnlineShop.Db.Model
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public Cart Cart { get; set; }

        public decimal Amount { get; set; }
    }
}
