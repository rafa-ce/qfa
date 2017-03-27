using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QFA.Models;
using QFA.TheMovieDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QFA.Repositorys
{
    public class GenreRepository
    {
        public GenreRepository() { }

        public async Task<List<Genre>> GenreMovieListAsync()
        {
            List<Genre> genres = new List<Genre>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TheMovieDbConfig.UrlBase);

                string requestUri = String.Format("genre/movie/list?api_key={0}&language={1}", TheMovieDbConfig.ApiKey, TheMovieDbConfig.DefaultLanguage);

                HttpResponseMessage response = await client.GetAsync(requestUri);

                var responseJson = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(responseJson);

                var values = obj["genres"];
                genres = JsonConvert.DeserializeObject<List<Genre>>(values.ToString());
            }

            return genres.OrderBy(g => g.Name).ToList();
        }

        public async Task<List<Movie>> ListMovieByGenreId(int id)
        {
            List<Movie> movies = new List<Movie>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TheMovieDbConfig.UrlBase);

                string requestUri = String.Format("genre/{0}/movie?api_key={1}&language={2}&&include_adult=false&sort_by=created_at.asc", 
                    id, TheMovieDbConfig.ApiKey, TheMovieDbConfig.DefaultLanguage);

                HttpResponseMessage response = await client.GetAsync(requestUri);

                var responseJson = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(responseJson);

                var values = obj["movies"];
                movies = JsonConvert.DeserializeObject<List<Movie>>(values.ToString());
            }

            return movies;
        }
    }
}
