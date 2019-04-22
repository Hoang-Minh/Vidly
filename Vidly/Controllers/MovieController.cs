using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : BaseController
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movies = MyDbContext.Movies.ToList();
            var movieViewController = new MovieViewModel {Movies = movies};

            return View(movieViewController);
        }

        public ActionResult Details(int id)
        {
            var movie = MyDbContext.Movies.Include(a => a.Genre).SingleOrDefault(x => x.Id == id);
            if (movie == null) return HttpNotFound("No such movie");
            var movieViewController = new MovieViewModel {Movie = movie};
            return View(movieViewController);
        }
    }
}