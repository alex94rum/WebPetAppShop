﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Model
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            this.CartItems = new List<CartItem>();
        }
    }
}
