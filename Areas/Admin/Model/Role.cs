using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Areas.Admin.Model
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
