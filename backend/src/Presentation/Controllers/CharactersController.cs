using Microsoft.AspNetCore.Mvc;
using StarWars_Cyclopedia.Application.DTOs;
using StarWars_Cyclopedia.Application.UseCases.GetCharacters;

namespace StarWars_Cyclopedia.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly GetCharactersHandler handler;

        public CharactersController(GetCharactersHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CharacterDto>>> Get([FromQuery] string characterName, CancellationToken cancellationToken)
        {
            var characters = await handler.HandleAsync(characterName, cancellationToken);
            return Ok(characters);
        }
    }
}
