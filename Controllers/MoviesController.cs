using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    // Step 2 - Create Controller
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        // Step 3 - Define Action
        // Step 4 - Create View
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "30 for 30"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Lowell"},
                new Customer {Name = "Erin"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
            //return View(movie);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortby = "name"});
        }


        public ActionResult Edit(int id)
        {
            // /movies/edit/1
            return Content("id=" + id);
        }

        // ? - makes the parameter "nullable"
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);

        }

        
    }
}