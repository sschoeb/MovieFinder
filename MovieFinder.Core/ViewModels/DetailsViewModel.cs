using Cirrious.MvvmCross.ViewModels;
using MovieFinder.Core.Model;
using MovieFinder.Core.Services;

namespace MovieFinder.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel
    {
        private readonly IRottenTomatoService _rottenTomatoService;

        public DetailsViewModel(IRottenTomatoService rottenTomatoService)
        {
            _rottenTomatoService = rottenTomatoService;
        }

        public async void Initialize(int movieId)
        {
            Movie = await _rottenTomatoService.RequestMovieDetailsAsync(movieId);
        }

        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; RaisePropertyChanged(() => Movie); }
        }
    }
}
