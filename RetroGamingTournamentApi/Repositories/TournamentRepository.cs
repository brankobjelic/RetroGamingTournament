using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly AppDbContext _context;
        public TournamentRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Tournament> Create(Tournament tournament)
        {
            await _context.AddAsync(tournament);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return tournament;
        }

        public Task Delete(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public async Task<Tournament> Get(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public Task<IEnumerable<Tournament>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
