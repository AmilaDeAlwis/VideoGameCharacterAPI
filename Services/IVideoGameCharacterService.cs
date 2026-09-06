using VideoGameCharacterAPI.DTOs;

namespace VideoGameCharacterAPI.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponseDTO>> GetAllCharacterAsync();
        Task<CharacterResponseDTO?> GetCharacterByIdAsync(int id);
        Task<CharacterResponseDTO> CreateCharacterAsync(CreateCharacterRequestDTO character);
        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequestDTO updatedCharacter);
        Task<bool> DeleteCharacterAsync(int id);
    }
}
