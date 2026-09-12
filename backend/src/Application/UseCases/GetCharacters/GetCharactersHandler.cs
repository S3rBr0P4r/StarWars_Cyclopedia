using StarWars_Cyclopedia.Application.DTOs;
using StarWars_Cyclopedia.Application.Mappings;
using StarWars_Cyclopedia.Domain.Interfaces;

namespace StarWars_Cyclopedia.Application.UseCases.GetCharacters
{
    public class GetCharactersHandler
    {
        private readonly ICharactersReader charactersReader;

        public GetCharactersHandler(ICharactersReader peopleReader)
        {
            charactersReader = peopleReader;
        }

        public async Task<IReadOnlyList<CharacterDto>> HandleAsync(string characterName, CancellationToken cancellationToken = default)
        {
            var characters = await charactersReader.GetCharactersByNameAsync(characterName, cancellationToken);
            var charactersDto = new List<CharacterDto>();

            foreach (var character in characters)
            {
                var characterDto = character.ToDto();
                charactersDto.Add(characterDto);
            }

            return charactersDto;
        }
    }   
}
