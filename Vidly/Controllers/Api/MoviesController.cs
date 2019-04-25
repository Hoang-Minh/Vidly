using System;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : BaseApiController
    {
        // GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(MyDbContext.Movies.ProjectTo<MovieDto>().ToList());
        }

        // GET api/movie/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = MyDbContext.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();

            var mappingProfile = new MappingProfile();
            var movieDto = mappingProfile.Mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            movieDto.DateAdded = DateTime.Now;
            var mappingProfile = new MappingProfile();
            var movie = mappingProfile.Mapper.Map<MovieDto, Movie>(movieDto);

            MyDbContext.Movies.Add(movie);
            MyDbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movieInDb = MyDbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null) return NotFound();
            
            var mappingProfile = new MappingProfile();
            mappingProfile.Mapper.Map(movieDto, movieInDb);

            MyDbContext.SaveChanges();
            return Ok("Movie got updated");
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = MyDbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null) return NotFound();

            MyDbContext.Movies.Remove(movieInDb);
            MyDbContext.SaveChanges();

            return Ok("Movie got deleted");
        }
    }
}
