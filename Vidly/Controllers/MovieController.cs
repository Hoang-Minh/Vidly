using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public List<Movie> movies = new List<Movie>
        {
            new Movie{Id = 1, Name = "Movie 1"},
            new Movie{Id = 2, Name = "Movie 2"}
        };

        // GET: Movie
        public ActionResult Index()
        {
            var movieViewController = new MovieViewModel {Movies = movies};

            return View(movieViewController);
        }

        public ActionResult Details(int id)
        {
            var movie = movies.Find(x => x.Id == id);
            if (movie == null) return HttpNotFound("No such movie");
            var movieViewController = new MovieViewModel {Movie = movie};
            return View(movieViewController);
        }
    }
}