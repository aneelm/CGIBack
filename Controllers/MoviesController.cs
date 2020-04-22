using System.Collections.Generic;
using CGIBack.Dto;
using CGIBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace CGIBack.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieService _movieService;


        public MoviesController(IMovieService movieService, ICategoryService categoryService)
        {
            _movieService = movieService;
            _movieService.SaveService(categoryService);
        }

        // GET: Movies
        public List<MovieDto> Index()
        {
            return _movieService.GetMovies();
        }

        // GET: Movies/Details/5
        public MovieDto Details(int id)
        {
            return _movieService.GetMoviesById(id);
        }

        // GET: Movies/search/?title=ghost
        public List<MovieDto> Search(string title)
        {
            return _movieService.GetMoviesByTitle(title);
        }

        // GET: Movies/filter/?categorieIds=1,2,3
        public List<MovieDto> Filter(string categorieIds)
        {
            return _movieService.GetMoviesByCategoryId(categorieIds);
        }

    }
}