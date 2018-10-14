using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieQuotes.Data.Models
{
    public class User
    {
        public User()
        {
        
        }
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }

         [Required]
        public string Password {get;set;}

    }
}
