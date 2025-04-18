using Newtonsoft.Json;
using System;

namespace WebPetAppShop.Models
{
    public class Product
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Cost")]
        public decimal Cost { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ImagePath")]
        public string ImagePath { get; set; }
    }
}
