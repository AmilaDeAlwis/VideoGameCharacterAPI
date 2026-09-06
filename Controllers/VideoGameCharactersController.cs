using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterAPI.DTOs;
using VideoGameCharacterAPI.Services;

namespace VideoGameCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponseDTO>>> GetCharacters()
            => Ok(await service.GetAllCharacterAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDTO>> GetCharacterById(int id) { 
            var character = await service.GetCharacterByIdAsync(id);
            return character is null ? NotFound("Character not found") : Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponseDTO>> CreateCharacter(CreateCharacterRequestDTO character)
        {
            var createdCharacter = await service.CreateCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacterById), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequestDTO updatedCharacter)
        {
            var result = await service.UpdateCharacterAsync(id, updatedCharacter);
            return result ? NoContent() : NotFound("Character not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var result = await service.DeleteCharacterAsync(id);
            return result ? NoContent() : NotFound("Character not found");
        }
    }
}
