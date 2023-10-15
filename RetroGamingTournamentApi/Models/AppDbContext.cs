
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
        public DbSet<GroupScore> GroupScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasData(
                new { Id = 1, Name = "Boris", IsActive = true },
                new { Id = 2, Name = "Bran", IsActive = true },
                new { Id = 3, Name = "Krsh", IsActive = true },
                new { Id = 4, Name = "Broox", IsActive = true },
                new { Id = 5, Name = "Peka", IsActive = true },
                new { Id = 6, Name = "Dule", IsActive = true },
                new { Id = 7, Name = "Saka", IsActive = true },
                new { Id = 8, Name = "Milan", IsActive = true },
                new { Id = 9, Name = "Bole", IsActive = true },
                new { Id = 10, Name = "Miki", IsActive = true },
                new { Id = 11, Name = "Rada", IsActive = true },
                new { Id = 12, Name = "Laush", IsActive = true }
            );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new { Id = 1, Name = "Mortal Kombat 3", GameType = 'A'},
                new { Id = 2, Name = "Micro Machines", GameType = 'B'}
            );
        }
    }
}
