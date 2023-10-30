using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;
        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Group> Create(Group group, List<int> playerIds)
        {
            var existingPlayers = await _context.Players.Where(p => playerIds.Contains(p.Id)).ToListAsync();
            group.Players = existingPlayers;
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public Task Delete(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
