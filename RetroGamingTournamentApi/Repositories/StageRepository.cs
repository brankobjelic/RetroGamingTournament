using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public class StageRepository : IStageRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Stage> _collection;
        public StageRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _collection = appDbContext.Stages;
        }
        public async Task<IEnumerable<Stage>> GetAll()
        {
            var stages = await _collection.AsNoTracking().ToListAsync();
            return stages;
        }
    }
}
