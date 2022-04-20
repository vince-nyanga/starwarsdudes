using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp3.Models;
using Newtonsoft.Json;

namespace ConsoleApp3.Services
{
    public class StarWarsService : IProvideStarWarsDudes
    {
        public async Task<IEnumerable<Dude>> GetCharacters(string url)
        {
            var dudes = new List<Dude>();
            var result = await FetchData(url);
            dudes.AddRange(result.Dudes);
            while (!string.IsNullOrEmpty(result.Next))
            {
                result = await FetchData(result.Next);
                dudes.AddRange(result.Dudes);
            }
            return dudes;
        }

        private async Task<(IEnumerable<Dude> Dudes, string Next)> FetchData(string uri)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            var stringContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(stringContent);
            return (apiResponse.Results, apiResponse.Next);
        }
    }
}