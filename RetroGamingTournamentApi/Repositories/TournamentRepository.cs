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
            List<Stage> tournamentStages = tournament.Stages.ToList();
            foreach (Stage stage in tournamentStages)
            {
                _context.Attach(stage); //attaching the existing stages to the context rather than creating new instances
            }
            await _context.Tournaments.AddAsync(tournament);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            tournament = _context.Tournaments.Include(t => t.Event).Include(t => t.Game).Single(t => t.Id == tournament.Id);
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

        public async Task<IEnumerable<Tournament>> GetByEventId(int id)
        {
            var tournamentList = await _context.Tournaments.Where(x => x.EventId == id).Include(x => x.Game).Include(x => x.Event).AsNoTracking().ToListAsync();
            return tournamentList;
        }
    }
}
