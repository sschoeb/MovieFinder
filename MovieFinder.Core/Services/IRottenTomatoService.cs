using System.Threading.Tasks;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public interface IRottenTomatoService
    {
        Task<RootObject> SearchMoviesAsync(string keyword);
        Task<Movie> RequestMovieDetailsAsync(int movieId);
    }
}
