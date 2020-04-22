using System;
using System.Collections.Generic;
using CGIBack.Models;

namespace CGIBack.Data
{
	public class MoviesList
	{
		public List<Movie> Movies = new List<Movie>()
			{
				new Movie()
				{
					Id = 1,
					Title = "When Harry Met Sally",
					ReleaseDate = DateTime.Parse("1989-2-12"),
					CategoryIds = new List<int>(){ 12, 5, 3 },
					Rating = 7,
					Description = "Hilarious"
				},
				new Movie()
				{
					Id = 2,
					Title = "Ghostbusters ",
					ReleaseDate = DateTime.Parse("1984-3-13"),
					CategoryIds = new List<int>(){ 3, 6, 14 },
					Rating = 10,
					Description = "Best movie I've ever seen"
				},
				new Movie
				{
					Id = 3,
					Title = "Ghostbusters 2",
					ReleaseDate = DateTime.Parse("1986-2-23"),
					CategoryIds = new List<int>(){ 3, 6, 14, 2 },
					Rating = 10,
					Description = "I take it back, this is the best movie I have ever seen"
				},
				new Movie
				{
					Id = 4,
					Title = "Rio Bravo",
					ReleaseDate = DateTime.Parse("1959-4-15"),
					CategoryIds = new List<int>(){ 1, 5, 12, 17 },
					Rating = 1,
					Description = "Action filled, wow!"
				}
			};


	}
}
