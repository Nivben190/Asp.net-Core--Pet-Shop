using System;
using System.ComponentModel.DataAnnotations;

namespace amirProject.Models
{
    public class Admin
    {


        [Required, StringLength(30, MinimumLength = 3)]
        public string? Email { get; set; }

        [Required]
        [StringLength(12)]
        
        public string ?Password { get; set; }

       
    }
}

