using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterAPI.Models;
using VideoGameCharacterAPI.Services;

namespace VideoGameCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
            => Ok(await service.GetAllCharacterAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id) { 
            var character = await service.GetCharacterByIdAsync(id);
            return character is null ? NotFound("Character not found") : Ok(character);
        }
    }
}
