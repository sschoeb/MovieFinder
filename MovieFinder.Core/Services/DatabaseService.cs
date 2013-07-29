using System.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public class DatabaseService
    {
        private const string DatabaseName = "database.sql";
        private readonly ISQLiteConnectionFactory _sqliteConnectionFactory;
        private readonly ISQLiteConnection _connection;

        public DatabaseService(ISQLiteConnectionFactory sqliteConnectionFactory)
        {
            _sqliteConnectionFactory = sqliteConnectionFactory;
            _connection = _sqliteConnectionFactory.Create(DatabaseName);
            _connection.CreateTable<Movie>();
        }

        public Movie GetMovieById(int movieId)
        {
            return _connection.Table<Movie>().SingleOrDefault(x => x.id.Equals(movieId.ToString()));
        }

        public void Insert(object item)
        {
            _connection.Insert(item);
        }
    }
}