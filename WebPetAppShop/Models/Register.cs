﻿using System.ComponentModel.DataAnnotations;

namespace WebPetAppShop.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string? UserName { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string? Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
