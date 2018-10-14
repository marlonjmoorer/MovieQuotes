using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieQuotes.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private MovieContext movieContext;

        public QuotesController(MovieContext movieContext){
            this.movieContext = movieContext;
        }
        [Route("random")]
         public ActionResult<IEnumerable<Quote>> Random()
        {
            return movieContext.Quotes
            .Include(q=>q.Movie)
            .OrderBy(q=> new Random().Next())
            .Take(5)
            .ToList();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> Get()
        {
            return movieContext.Quotes.ToList();
        }

        
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            return movieContext.Movies.Find(id);
        }

       
        [HttpPost]
        public IActionResult Post([FromBody]Quote value)
        {
            var movie= movieContext.Movies
                .Include(m=>m.Quotes)
                .SingleOrDefault(m=>m.Id==value.MovieId);
            movie?.Quotes.Add(value);
            movieContext.SaveChanges();
            return Json(new{message="Success"});
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movie=movieContext.Movies.Find(id);
            if(movie!=null){
                movieContext.Movies.Remove(movie);
                movieContext.SaveChanges();
            }
            

        }
    }
}
