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
        public async Task<Group> Create(Group group, List<int> playerIds, int[][][] roundRobinScheme)
        {
            var existingPlayers = await _context.Players.Where(p => playerIds.Contains(p.Id)).ToListAsync();
            existingPlayers = existingPlayers.OrderBy(p => playerIds.IndexOf(p.Id)).ToList();   //reorder to match the order of received list of playerIds
            group.Players = existingPlayers;
            for (int i = 0; i < roundRobinScheme.Length; i++)
            {
                for (int j = 0; j < roundRobinScheme[i].Length; j++)
                {
                    var player1 = existingPlayers[roundRobinScheme[i][j][0] - 1];
                    var player2 = existingPlayers[roundRobinScheme[i][j][1] - 1];
                    ICollection<Player> MatchPlayers = new List<Player>
                    {
                        player1, player2
                    };
                    Match match = new Match
                    {
                        P1 = player1,
                        P2 = player2
                    };
                    await _context.Matches.AddAsync(match);
                    await _context.SaveChangesAsync();
                    group.Matches.Add(match);
                }
            }

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
