using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Models
{
    public class ChangePassword
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string? Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
