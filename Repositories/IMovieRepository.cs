using System;
using System.Collections.Generic;
using System.Linq;
using CGIBack.Data;
using CGIBack.Dto;
using CGIBack.Models;
using CGIBack.Services;

namespace CGIBack.Repositories
{
	public interface IMovieRepository
	{
		List<MovieDto> GetMovies();
		MovieDto GetMoviesById(int id);
		List<MovieDto> GetMoviesByTitle(string searchString);

		List<MovieDto> GetMoviesByCategoryId(string categorieIds);

		void SaveService(ICategoryService _categoryService);
	}

	public class MovieRepository : IMovieRepository
	{
		readonly List<Movie> Movies = new MoviesList().Movies;
		private ICategoryService _categoryService;

		public void SaveService(ICategoryService CategoryService)
		{
			_categoryService = CategoryService;
		}
		public List<MovieDto> GetMovies()
		{
			var movies = from movie in Movies
						 select new MovieDto()
						 {
							 Id = movie.Id,
							 Title = movie.Title,
							 ReleaseDate = movie.ReleaseDate,
							 Categories = _categoryService.GetCategoryNamesById(movie.CategoryIds),
							 Rating = movie.Rating,
							 Description = movie.Description
						 };
			return movies.ToList();
		}
		public List<MovieDto> GetMoviesByCategoryId(string categorieIds)
		{
			if (categorieIds.Length == 0)
			{
				return new List<MovieDto>();
			}
			List<string> numberStringList = categorieIds.Split(",").Select(p => p.Trim()).ToList();
			List<int> categorieIdsList = numberStringList.Select(s => Int32.Parse(s)).ToList();
			HashSet<Movie> movies = new HashSet<Movie>();
			foreach (int id in categorieIdsList)
			{
				movies.UnionWith(Movies.Where(s => s.CategoryIds.Contains(id)).ToHashSet());
			}
			var moviesDto = from movie in movies
							select new MovieDto()
							{
								Id = movie.Id,
								Title = movie.Title,
								ReleaseDate = movie.ReleaseDate,
								Categories = _categoryService.GetCategoryNamesById(movie.CategoryIds),
								Rating = movie.Rating,
								Description = movie.Description
							};
			return moviesDto.ToList();
		}

		public MovieDto GetMoviesById(int id)
		{
			Movie movie = Movies.Where(s => s.Id.Equals(id)).FirstOrDefault();
			if (movie != null)
			{
				var movieDto = new MovieDto()
				{
					Id = movie.Id,
					Title = movie.Title,
					ReleaseDate = movie.ReleaseDate,
					Categories = _categoryService.GetCategoryNamesById(movie.CategoryIds),
					Rating = movie.Rating,
					Description = movie.Description
				};
				return movieDto;
			}
			return new MovieDto();
		}

		public List<MovieDto> GetMoviesByTitle(string searchString)
		{
			if (!String.IsNullOrEmpty(searchString))
			{
				var movies = Movies.Where(s => s.Title.ToLower().Contains(searchString)).ToList();
				var moviesDto = from movie in movies
								select new MovieDto()
								{
									Id = movie.Id,
									Title = movie.Title,
									ReleaseDate = movie.ReleaseDate,
									Categories = _categoryService.GetCategoryNamesById(movie.CategoryIds),
									Rating = movie.Rating,
									Description = movie.Description
								};
				return moviesDto.ToList();
			}
			return new List<MovieDto>();
		}
	}
}
