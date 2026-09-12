using StarWars_Cyclopedia.Application.DTOs;
using StarWars_Cyclopedia.Domain.Entities;

namespace StarWars_Cyclopedia.Application.Mappings
{
    public static class PeopleMappingExtensions
    {
        public static CharacterDto ToDto(this Character character)
        {
            return new CharacterDto
            {
                Name = character.Name,
                Height = character.Height
            };
        }
    }
}
