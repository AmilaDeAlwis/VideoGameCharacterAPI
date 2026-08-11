using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        static List<Character> characters = new List<Character>{
            new Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
            new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
            new Character { Id = 3, Name = "Bowser", Game = "Super Mario Bros.", Role = "Villain" },
        };

        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharacterAsync()
            => await Task.FromResult(characters);

        public Task<Character> GetCharacterByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
