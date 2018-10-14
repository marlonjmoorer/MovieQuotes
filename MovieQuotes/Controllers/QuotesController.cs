using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieQuotes.Data;
using MovieQuotes.Data.Models;
using Microsoft.EntityFrameworkCore;
using MovieQuotes.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieQuotes.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private MovieService movieService;

        public QuotesController(MovieService movieService){
            this.movieService=movieService;
        }
        [Route("random")]
         public ActionResult<IEnumerable<Quote>> Random()
        {
            return movieService.RandomQuotes().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Quote>> Get()
        {
            return movieService.GetQuotes().ToList();
        }

        
    

       
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            movieService.AddQuote(quote);
            return Json(new{message="Success"});
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
