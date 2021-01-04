using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;

namespace WebApplication8.Controllers
{
    public class TestController : Controller
    {
        private readonly DataBase _context;

        public TestController(DataBase context)
        {
            _context = context;
        }

        public IActionResult khan()
        {
            return Content( "it is sajad");
        }

        [HttpPost]
        public async Task<IActionResult> SearchMovie()
        {
            string paramater1 = Request.Form["SearchString"];

            var movies = from m in _context.Movie
                         select m;
            //var search = await _context.Movie.ToListAsync();
            //IEnumerable<string> query = _context.Movie.Where(fruit => fruit.Length < 6); ;
            if (!String.IsNullOrEmpty(paramater1))
            {
                movies = movies.Where(s => s.Title.Contains(paramater1));
                //if(movies == null) {
                //   movies = await _context.Movie.ToListAsync()
                //}
            }
            else
            {
                return Content("Okk");
            }
            return View("../Movies/Index", movies);
        }

        public IActionResult ajax()
        {
            return Content("it is ajax request from Controller");
        }

    }

}