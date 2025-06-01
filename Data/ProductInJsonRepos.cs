using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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

        public void Add(Product product)
        {
            var productRepos = this.GetAll();

            product.Id = Guid.NewGuid();
            product.ImagePath = "/images/" + product.ImagePath;

            productRepos?.Add(product);

            var path = @"D:\CSharp_folder\WebPetAppShop\WebPetAppShop\Products.json";

            string json = JsonConvert.SerializeObject(productRepos, Formatting.Indented);

            System.IO.File.WriteAllText(path, json);
        }

        public void Update(Product product)
        {
            var productRepos = this.GetAll();

            var exstingProduct = productRepos?.FirstOrDefault(x =>x.Id == product.Id);

            if (exstingProduct == null)
            {
                return;
            }

            exstingProduct.Name = product.Name;
            exstingProduct.Cost = product.Cost;
            exstingProduct.Description = product.Description;
            exstingProduct.ImagePath = product.ImagePath;

            var path = @"D:\CSharp_folder\WebPetAppShop\WebPetAppShop\Products.json";

            string json = JsonConvert.SerializeObject(productRepos, Formatting.Indented);

            System.IO.File.WriteAllText(path, json);
        }
    }
}
