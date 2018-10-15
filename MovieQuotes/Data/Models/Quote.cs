using System;
using System.ComponentModel.DataAnnotations;

namespace MovieQuotes.Data.Models
{
    public class Quote
    {
        public Quote()
        {
        }
        public int Id { get; set; }
        public string Text { get; set; }
        
        [Required]
        public int MovieId { get; set; }

        public Movie Movie {get;set;}
    }
}
