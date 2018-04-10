﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieRental.Models;


namespace MovieRental.Data
{
    class MovieRentalContext : DbContext
    {
        public MovieRentalContext()
            : base()
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

    public class MOvieRepository
    {
        MovieRentalContext db = new MovieRentalContext();

        public Movie GetMovie(string id)
        {
            IEnumerable<Genre> l = db.Genres;
            return db.Movies.Single(m => m.MovieId == id);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies;
        }

        public void Add(Movie movie)
        {
            for (int i = 0; i < movie.Genres.Count; i++)
            {
                string genreDesc = movie.Genres[i].Description;
                Genre existingGenre = db.Genres.SingleOrDefault(e => e.Description == genreDesc);
                if (existingGenre != null)
                {
                    movie.Genres[i] = existingGenre;
                }
            }
            db.Movies.Add(movie);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return db.Genres;
        }

        public void Delete(string id)
        {
            Movie movie = db.Movies.Single(m => m.MovieId == id);
            db.Movies.Remove(movie);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Movie> FindMoviesByTitle(string title)
        {
            return db.Movies.Where(m => m.Title.ToLower().Contains(title));
        }
    }
}
