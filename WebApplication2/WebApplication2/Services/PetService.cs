using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class PetService : IPetService
    {
        private readonly HttpClient _httpClient;

        public PetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Breed>> GetBreedsAsync()
        {
            var response = await _httpClient.GetAsync("https://catfact.ninja/breeds");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var breeds = JObject.Parse(content)["data"].ToObject<List<Breed>>();

            return breeds;
        }
    }
}
