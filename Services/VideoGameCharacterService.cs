using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Data;
using VideoGameCharacterAPI.DTOs;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<CharacterResponseDTO> CreateCharacterAsync(CreateCharacterRequestDTO character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };
            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();
            return new CharacterResponseDTO
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);
            if (characterToDelete is null)
            {
                return false;
            }
            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CharacterResponseDTO>> GetAllCharacterAsync() 
            => await context.Characters.Select(c => new CharacterResponseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public async Task<CharacterResponseDTO?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequestDTO updatedCharacter)
        {
            var characterToUpdate = await context.Characters.FindAsync(id);
            if (characterToUpdate is null)
            {
                return false;
            }

            characterToUpdate.Name = updatedCharacter.Name;
            characterToUpdate.Game = updatedCharacter.Game;
            characterToUpdate.Role = updatedCharacter.Role;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
