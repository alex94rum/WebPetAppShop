using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Models
{
    public class Product
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("Cost")]
        [Required]
        [Range(1, 1000, ErrorMessage ="Цена должна быть в пределах от 1 дл 1000$")]
        public decimal Cost { get; set; }

        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty("ImagePath")]
        public string ImagePath { get; set; }
    }
}
