using Cirrious.MvvmCross.ViewModels;
using MovieFinder.Core.Model;
using MovieFinder.Core.Services;

namespace MovieFinder.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel
    {
        private readonly CachedRottenTomatoService _cachedRottenTomatoService;
        private int _movieId;

        public DetailViewModel(CachedRottenTomatoService cachedRottenTomatoService)
        {
            _cachedRottenTomatoService = cachedRottenTomatoService;
        }

        public void Init(int movieId)
        {
            _movieId = movieId;
        }

        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; RaisePropertyChanged(() => Movie); }
        }

        public override void Start()
        {
            _cachedRottenTomatoService.RequestMovieDetails(_movieId, newMovie => Movie = newMovie);
        }
    }
}
