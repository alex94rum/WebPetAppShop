using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
