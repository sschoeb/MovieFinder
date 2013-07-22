using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MovieFinder.Core.Model;
using MovieFinder.Core.Services;

namespace MovieFinder.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly IRottenTomatoService _rottenTomatoService;

        public FirstViewModel(IRottenTomatoService rottenTomatoService)
        {
            _rottenTomatoService = rottenTomatoService;

            SearchCommand = new MvxCommand(SearchCommandExecute);
            ShowDetailCommand = new MvxCommand<Movie>(movie => ShowViewModel<DetailsViewModel>(new { movieId = movie.id }));
        }

        private string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; RaisePropertyChanged(() => Keyword); }
        }

        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; RaisePropertyChanged(() => Movies); }
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand ShowDetailCommand { get; private set; }

        private async void SearchCommandExecute()
        {
            RootObject data = await _rottenTomatoService.SearchMoviesAsync(Keyword);
            Movies = new ObservableCollection<Movie>(data.movies);
        }
    }
}
