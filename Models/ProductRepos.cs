using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Extensions;

namespace WebPetAppShop.Models
{
    public class ProductRepos
    {
        public List<Product>? Products { get; }

        public ProductRepos()
        {
            var path = @"D:\CSharp_folder\WebPetAppShop\WebPetAppShop\Products.json";
            string json = System.IO.File.ReadAllText(path);
            this.Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public Product? TryByGuid(Guid guid)
        {
            return this.Products?.FirstOrDefault(x => x.Id == guid);
        }
    }
}
