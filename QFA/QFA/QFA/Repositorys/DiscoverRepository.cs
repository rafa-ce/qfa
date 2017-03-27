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
    public class DiscoverRepository
    {
        public DiscoverRepository() { }

        public async Task<List<Movie>> DiscoverMoviesByGenreIdAsync(int genreId)
        {
            List<Movie> movies = new List<Movie>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TheMovieDbConfig.UrlBase);

                string requestUri = string.Format("discover/movie?api_key={0}&language={1}&sort_by=vote_count.desc&include_adult=false&include_video=false&page=1&with_genres={2}",
                    TheMovieDbConfig.ApiKey, TheMovieDbConfig.DefaultLanguage, genreId);

                HttpResponseMessage response = await client.GetAsync(requestUri);

                var responseJson = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(responseJson);

                var values = obj["results"];
                movies = JsonConvert.DeserializeObject<List<Movie>>(values.ToString());
            }

            return movies;
        }
    }
}
