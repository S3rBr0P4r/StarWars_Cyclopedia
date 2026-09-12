using StarWars_Cyclopedia.Application.Interfaces;
using StarWars_Cyclopedia.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace StarWars_Cyclopedia.Infrastructure.Services
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClientWrapper(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IReadOnlyList<Character>> GetCharactersAsync(string characterName, CancellationToken cancellationToken)
        {
            var people = new List<Character>();
            using (var client = httpClientFactory.CreateClient("StarWarsApi"))
            {
                using var response = await client.GetAsync($"people/?search={characterName}", cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
                    var jsonNode = JsonNode.Parse(jsonString);
                    var results = jsonNode!["results"]!.AsArray();
                    foreach (JsonNode resultNode in results)
                    {
                        var character = JsonSerializer.Deserialize<Character>(resultNode.ToJsonString());
                        people.Add(character);
                    }
                }
            }

            return people;
        }
    }
}
