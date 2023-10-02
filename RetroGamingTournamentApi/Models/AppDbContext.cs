
using Microsoft.EntityFrameworkCore;

namespace RetroGamingTournament.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }


    }
}
