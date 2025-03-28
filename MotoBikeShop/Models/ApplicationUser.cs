﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public  string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
        public DateTime DaySignUp { get; set; }

    }

}
