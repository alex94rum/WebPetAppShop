﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebPetAppShop.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<CartItem>? Items { get; set; }

        public decimal Cost
        {
            get
            {
                return this.Items?.Sum(x => x.Cost) ?? 0; 
            }
        }
    }
}
