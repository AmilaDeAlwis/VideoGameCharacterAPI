namespace VideoGameCharacterAPI.DTOs
{
    public class UpdateCharacterRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
