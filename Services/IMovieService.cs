using CGIBack.Repositories;

namespace CGIBack.Services
{
    public interface IMovieService : IMovieRepository { }
    public class MovieService : MovieRepository, IMovieService { }
}
