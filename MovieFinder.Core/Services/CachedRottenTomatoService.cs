using System;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public class CachedRottenTomatoService : ICachedRottenTomatoService
    {
        private readonly IDatabaseService _databaseService;
        private readonly IRottenTomatoRestService _rottenTomatoRestService;

        public CachedRottenTomatoService(IDatabaseService databaseService, IRottenTomatoRestService rottenTomatoRestService)
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