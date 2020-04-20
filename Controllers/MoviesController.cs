using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGIBack.Services;
using CGIBack.Models;
using CGIBack.Dto;
using Microsoft.AspNetCore.Http;
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

        // GET: Movies/filter
        public List<MovieDto> Filter(string categorieIds)
        {
            return _movieService.GetMoviesByCategoryId(categorieIds);
        }
            
        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}