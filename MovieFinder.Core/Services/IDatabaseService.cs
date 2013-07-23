using System.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public interface IDatabaseService
    {
        Movie GetMovieById(int movieId);
        void Insert(object item);
    }

    public class DatabaseService : IDatabaseService
    {
        private const string DatabaseName = "MovieFinderDatabase";
        private readonly ISQLiteConnectionFactory _sqliteConnectionFactory;

        public DatabaseService(ISQLiteConnectionFactory sqliteConnectionFactory)
        {
            _sqliteConnectionFactory = sqliteConnectionFactory;
            using (ISQLiteConnection connection = _sqliteConnectionFactory.Create(DatabaseName))
            {
                connection.CreateTable<Movie>();
            }
        }

        public Movie GetMovieById(int movieId)
        {
            using (ISQLiteConnection connection = _sqliteConnectionFactory.Create(DatabaseName))
            {
                return connection.Table<Movie>().SingleOrDefault(x => x.id.Equals(movieId.ToString()));
            }
        }

        public void Insert(object item)
        {
            using (ISQLiteConnection connection = _sqliteConnectionFactory.Create(DatabaseName))
            {
                connection.Insert(item);
            }
        }
    }
}