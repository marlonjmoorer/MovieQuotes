using System;
namespace MovieQuotes.Data.Models
{
    public class Quote
    {
        public Quote()
        {
        }
        public int Id { get; set; }
        public string Text { get; set; }

        public int MovieId { get; set; }

        public Movie Movie {get;set;}
    }
}
