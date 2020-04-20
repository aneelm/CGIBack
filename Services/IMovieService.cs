using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGIBack.Repositories;

namespace CGIBack.Services
{
	public interface IMovieService : IMovieRepository { }
	public class MovieService : MovieRepository, IMovieService { }
}
