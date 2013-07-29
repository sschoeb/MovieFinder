using System;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public class CachedRottenTomatoService
    {
        private readonly DatabaseService _databaseService;
        private readonly RottenTomatoRestService _rottenTomatoRestService;

        public CachedRottenTomatoService(DatabaseService databaseService, RottenTomatoRestService rottenTomatoRestService)
        {
            _databaseService = databaseService;
            _rottenTomatoRestService = rottenTomatoRestService;
        }

        public void RequestMovieDetails(int movieId, Action<Movie> callback)
        {
            Movie cachedMovie = _databaseService.GetMovieById(movieId);
            if (cachedMovie != null)
            {
                callback(cachedMovie);
                return;
            }

            _rottenTomatoRestService.RequestMovieDetails(movieId, movie => CacheCallback(movie, callback));
        }

        private void CacheCallback(Movie movie, Action<Movie> callback)
        {
            _databaseService.Insert(movie);
            callback(movie);
        }
    }
}