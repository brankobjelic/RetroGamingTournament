using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Player> _collection;
        public PlayerRepository(AppDbContext context) {
            _context = context;
            _collection = _context.Players;
        }
        public Task<Player> Create(Player player)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<Player> Get(int id)
        {
            return _collection.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            var players = await _collection.AsNoTracking().ToListAsync();
            return players;
        }
    }
}
