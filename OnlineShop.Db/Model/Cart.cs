using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Model
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public Cart()
        {
            this.Items = new List<CartItem>();
        }
    }
}
