using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string genre)
        {
            MovieRepository rep = new MovieRepository();
            IEnumerable<Genre> genres = rep.GetAllGenres();
            IEnumerable<Movie> movies = rep.GetAllMovies();
            if (!string.IsNullOrEmpty(genre))
            {
                Genre selectedGenre = genres.SingleOrDefault(g =>g.Description == genre);
                if (null == selectedGenre)
                {
                    movies = rep.GetAllMovies();
                }
                else
                {
                    movies = selectedGenre.Movies;
                }
            }
            else
            {
                movies = rep.GetAllMovies();
            }
            ViewBag.Genres = genres;

            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}