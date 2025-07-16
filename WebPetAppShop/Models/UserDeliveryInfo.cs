using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Models
{
    public class UserDeliveryInfo
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}
