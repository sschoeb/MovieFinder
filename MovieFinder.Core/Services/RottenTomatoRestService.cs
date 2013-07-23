using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Cirrious.CrossCore.Platform;
using MovieFinder.Core.Model;

namespace MovieFinder.Core.Services
{
    public class RottenTomatoRestService : IRottenTomatoRestService
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private const string SearchUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey={0}&q={1}";
        private const string DetailUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/{1}.json?apikey={0}";
        private const string ApiKey = "bw69bq8jp2wwqc86p8fcezwc";

        //public async Task<RootObject> SearchMoviesAsync(string keyword)
        //{
        //    return await DoRequest<RootObject>(string.Format(SearchUrl, ApiKey, keyword));
        //}

        //public async Task<Movie> RequestMovieDetailsAsync(int movieId)
        //{
        //    return await DoRequest<Movie>(string.Format(DetailUrl, ApiKey, movieId));
        //}

        //private async Task<T> DoRequest<T>(string url)
        //{
        //    var client = new HttpClient();
        //    HttpResponseMessage message = await client.GetAsync(url);

        //    if (message.IsSuccessStatusCode)
        //    {
        //        using (var stream = await message.Content.ReadAsStreamAsync())
        //        {
        //            using (var streamReader = new StreamReader(stream))
        //            {
        //                string content = await streamReader.ReadToEndAsync();
        //                T result = await JsonConvert.DeserializeObjectAsync<T>(content);
        //                return result;
        //            }
        //        }
        //    }

        //    return default(T);
        //}

        public RottenTomatoRestService(IMvxJsonConverter jsonConverter )
        {
            _jsonConverter = jsonConverter;
        }

        public void SearchMovies(string keyword, Action<RootObject> callback)
        {
            var request = WebRequest.Create(string.Format(SearchUrl, ApiKey, keyword));
            request.BeginGetResponse(asyncResult => HandleRequestResponse(asyncResult, callback), request);
        }

        public void RequestMovieDetails(int movieId, Action<Movie> callback)
        {
            var request = WebRequest.Create(string.Format(DetailUrl, ApiKey, movieId));
            request.BeginGetResponse(asyncResult => HandleRequestResponse(asyncResult, callback),request);
        }

        private void HandleRequestResponse<T>(IAsyncResult asyncResult, Action<T> callback)
        {
            var request1 = (HttpWebRequest)asyncResult.AsyncState;
            var response = (HttpWebResponse)request1.EndGetResponse(asyncResult);
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string resultString = streamReader.ReadToEnd();
                callback(_jsonConverter.DeserializeObject<T>(resultString));
            }
        }
    }
}