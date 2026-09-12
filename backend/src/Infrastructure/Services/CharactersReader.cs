using StarWars_Cyclopedia.Application.Interfaces;
using StarWars_Cyclopedia.Domain.Entities;
using StarWars_Cyclopedia.Domain.Interfaces;

namespace StarWars_Cyclopedia.Infrastructure.Services
{
    public class CharactersReader : ICharactersReader
    {
        private readonly IHttpClientWrapper httpClientWrapper;

        public CharactersReader(IHttpClientWrapper httpClientWrapper) 
        {
            this.httpClientWrapper = httpClientWrapper;
        }

        public async Task<IReadOnlyList<Character>> GetCharactersByNameAsync(string characterName, CancellationToken cancellationToken = default)
        {
            var charactersData = await httpClientWrapper.GetCharactersAsync(characterName, cancellationToken);

            if (charactersData.Count.Equals(0))
                return new List<Character>();

            var characters = charactersData.Where(cd => cd.Name.StartsWith(characterName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return characters;
        }
    }
}
