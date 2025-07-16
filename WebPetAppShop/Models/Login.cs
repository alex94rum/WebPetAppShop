using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Имя обязательно")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string? Password { get; set; }

        public bool Remember { get; set; }
    }
}
