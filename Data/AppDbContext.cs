using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Data
{
    public class AppDbContext (DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Models.Character> Characters => Set<Character>();
    }
}
