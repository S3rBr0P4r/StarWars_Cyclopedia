using StarWars_Cyclopedia.Domain.Entities;

namespace StarWars_Cyclopedia.Domain.Interfaces
{
    public interface ICharactersReader
    {
        public Task<IReadOnlyList<Character>> GetCharactersByNameAsync(string characterName, CancellationToken cancellationToken = default);
    }
}
