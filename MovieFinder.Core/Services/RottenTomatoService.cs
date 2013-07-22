using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MovieFinder.Core.Model;
using Newtonsoft.Json;

namespace MovieFinder.Core.Services
{
    public class RottenTomatoService : IRottenTomatoService
    {
        private const string SearchUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey={0}&q={1}";
        private const string DetailUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/{1}.json?apikey={0}";
        private const string ApiKey = "bw69bq8jp2wwqc86p8fcezwc";

        public async Task<RootObject> SearchMoviesAsync(string keyword)
        {
            return await DoRequest<RootObject>(string.Format(SearchUrl, ApiKey, keyword));
        }

        public async Task<Movie> RequestMovieDetailsAsync(int movieId)
        {
            return await DoRequest<Movie>(string.Format(DetailUrl, ApiKey, movieId));
        }

        private static async Task<T> DoRequest<T>(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(url);

            if (message.IsSuccessStatusCode)
            {
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        string content = await streamReader.ReadToEndAsync();
                        T result = await JsonConvert.DeserializeObjectAsync<T>(content);
                        return result;
                    }
                }
            }

            return default(T);
        }
    }
}