using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieQuotes.Controllers
{
    [Route("api/movies/{movieId:int}/[controller]")]
    public class QuotesController : Controller
    {
        private MovieContext movieContext;

        public QuotesController(MovieContext movieContext){
            this.movieContext = movieContext;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return movieContext.Movies.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            return movieContext.Movies.Find(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            var movie=movieContext.Add(value);
            movieContext.SaveChanges();
            return Ok(new{id =1,message="Success"});
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
