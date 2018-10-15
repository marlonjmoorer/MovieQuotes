using System;
using Microsoft.EntityFrameworkCore;
using MovieQuotes.Data.Models;

namespace MovieQuotes.Data
{
    public class MovieContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DbSet<User> Users { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {
        }
        
    }
}
