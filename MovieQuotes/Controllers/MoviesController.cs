using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;
using Microsoft.EntityFrameworkCore;
using MovieQuotes.Services;
using Microsoft.AspNetCore.Authorization;

namespace MovieQuotes.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IMovieService movieService;

        public MoviesController(IMovieService service){
            this.movieService=service;
        }
      
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get([FromQuery(Name = "title")] string title=null,[FromQuery(Name = "year")] string year=null)
        {
            return movieService.GetFilteredMovies(title,year).ToList();
        }

      
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie= movieService.GetMovieById(id);
            return movie;
                    
        }

     
        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            if(movieService.AddMovie(movie)){
                 return Json(new{message="Success"});
            }
            return Json(new{message="Failure"});
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(movieService.DeleteMovie(id)){
                 return Json(new{message="Success"});
            }
            return Json(new{message="Failure"});
        }
    }
}
