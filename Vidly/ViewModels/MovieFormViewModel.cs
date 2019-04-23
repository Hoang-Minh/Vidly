using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}