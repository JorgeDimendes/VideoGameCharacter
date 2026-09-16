using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Api.Models;

namespace VideoGameCharacter.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Personagem> Personagens { get; set; }
    }
}