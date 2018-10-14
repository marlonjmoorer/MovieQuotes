using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieQuotes.Services
{
    public interface IMovieService
    {

       IEnumerable<Movie> GetFilteredMovies(string title,string year);
       Movie GetMovieById(int id);

       bool AddMovie(Movie movie);

       bool DeleteMovie(int id);

       bool AddQuote(Quote quote); 
       IEnumerable<Quote> RandomQuotes();

       IEnumerable<Quote> GetQuotes();

    }

    public class MovieService : IMovieService
    {

        private readonly MovieContext context;

        public MovieService(MovieContext context)
        {
            this.context=context;
            
        }

        

  
        public IEnumerable<Movie> GetFilteredMovies(string title=null,string year=null){
            var query=context.Movies.AsQueryable();
            if(!String.IsNullOrEmpty(title)){
                query=query.Where(m=>m.Title.Contains(title));
            }
            if(!String.IsNullOrEmpty(year)){
                query=query.Where(m=>m.Year==year);
            }
            return query;
        }
        public Movie GetMovieById(int id)
        {
            var movie= context.Movies
            .Include(m=>m.Quotes)
            .SingleOrDefault(m=>m.Id==id);
            return movie;
        }
        public bool AddMovie(Movie movie){
           context.Add(movie);
           return context.SaveChanges()==1;
        }
        public bool DeleteMovie(int id){
            var movie=context.Movies.Find(id);
            if(movie!=null){
                context.Movies.Remove(movie);
                return context.SaveChanges()==1;
            }
            return false;
        }

        public bool AddQuote(Quote quote)
        {
            var movie= context.Movies
                .Include(m=>m.Quotes)
                .SingleOrDefault(m=>m.Id==quote.MovieId);
            movie?.Quotes.Add(quote);
            return context.SaveChanges()==1;
        }

        public IEnumerable<Quote> RandomQuotes()
        {
            return context.Quotes
            .Include(q=>q.Movie)
            .OrderBy(q=>new Random().Next())
            .Take(5);
        }

        public IEnumerable<Quote> GetQuotes()
        {
           return context.Quotes.ToList();
        }
    }
}