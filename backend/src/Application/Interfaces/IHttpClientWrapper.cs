using StarWars_Cyclopedia.Domain.Entities;

namespace StarWars_Cyclopedia.Application.Interfaces
{
    public interface IHttpClientWrapper
    {
        public Task<IReadOnlyList<Character>> GetCharactersAsync(string characterName, CancellationToken cancellationToken);
    }
}
