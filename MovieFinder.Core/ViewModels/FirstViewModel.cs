using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MovieFinder.Core.Model;
using MovieFinder.Core.Services;

namespace MovieFinder.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly RottenTomatoRestService _rottenTomatoRestService;

        public FirstViewModel(RottenTomatoRestService rottenTomatoRestService)
        {
            _rottenTomatoRestService = rottenTomatoRestService;

            SearchCommand = new MvxCommand(SearchCommandExecute);
            ShowDetailCommand = new MvxCommand<Movie>(movie => ShowViewModel<DetailViewModel>(new { movieId = movie.id }));
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

        private void SearchCommandExecute()
        {
            _rottenTomatoRestService.SearchMovies(Keyword, data =>
                {
                    Debug.WriteLine("Got new Movies" + data.movies.Count);
                    Movies = new ObservableCollection<Movie>(data.movies);
                });
        }
    }
}
