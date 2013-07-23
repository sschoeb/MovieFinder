using System;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public interface ICachedRottenTomatoService
    {
        void RequestMovieDetails(int movieId, Action<Movie> callback);
    }
}
