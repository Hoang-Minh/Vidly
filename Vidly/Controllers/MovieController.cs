using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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
            var movies = MyDbContext.Movies.Include(x => x.Genre).ToList();
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

        public ActionResult New()
        {
            var emptyMovieFormViewModel = new MovieFormViewModel
            {
                Genre = MyDbContext.Genres.ToList()
            };

            return View("MovieForm", emptyMovieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var emptyMovieFormViewModel = new MovieFormViewModel(movie)
                {
                    Genre = MyDbContext.Genres.ToList()
                };

                return View("MovieForm", emptyMovieFormViewModel);
            }

            var movieInDb = MyDbContext.Movies.SingleOrDefault(x => x.Id == movie.Id);

            if (movieInDb == null) return HttpNotFound("Movie not found in database");

            MyDbContext.Movies.AddOrUpdate(movie);

            MyDbContext.SaveChanges();


            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = MyDbContext.Movies.Find(id);
            if (movie == null) return HttpNotFound("Movie cannot be found");

            var movieFormViewModel = new MovieFormViewModel(movie)
            {
                Genre = MyDbContext.Genres.ToList()
            };

            return View("MovieForm", movieFormViewModel);
        }
    }
}