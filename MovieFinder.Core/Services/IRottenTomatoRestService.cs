using System;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public interface IRottenTomatoRestService
    {
        //Task<RootObject> SearchMoviesAsync(string keyword);
        //Task<Movie> RequestMovieDetailsAsync(int movieId);

        void SearchMovies(string keyword, Action<RootObject> callback);
        void RequestMovieDetails(int movieId, Action<Movie> callback);
    }
}
