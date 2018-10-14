using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieQuotes.Data.Models
{
    public class Movie
    {
        public Movie()
        {
        }
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

         [Required]
         public string Year {get;set;}

        public ICollection<Quote> Quotes { get; set; }
    }
}
