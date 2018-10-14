using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieQuotes.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private MovieContext movieContext;

        public MoviesController(MovieContext movieContext){
            this.movieContext = movieContext;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get([FromQuery(Name = "title")] string title=null,[FromQuery(Name = "year")] string year=null)
        {
          
            var query=movieContext.Movies.AsQueryable();
            if(!String.IsNullOrEmpty(title)){
                query=query.Where(m=>m.Title.Contains(title));
            }
            if(!String.IsNullOrEmpty(year)){
                query=query.Where(m=>m.Year==year);
            }
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie= movieContext.Movies
                .Include(m=>m.Quotes)
                .SingleOrDefault(m=>m.Id==id);
            return movie;
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
