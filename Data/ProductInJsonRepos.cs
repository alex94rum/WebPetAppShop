using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Extensions;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class ProductInJsonRepos : IProductRepos
    {
        public List<Product>? GetAll()
        {
            var path = @"D:\CSharp_folder\WebPetAppShop\WebPetAppShop\Products.json";
            string json = System.IO.File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public Product? TryByGuid(Guid guid)
        {
            return this.GetAll()?.FirstOrDefault(x => x.Id == guid);
        }

    }
}
