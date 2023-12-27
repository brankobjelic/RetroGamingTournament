using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;
using System.Numerics;

namespace RetroGamingTournament.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;
        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<Group> Create(Group group, int[][][] roundRobinScheme)
        //{
        //    //var existingPlayers = await _context.Players.Where(p => playerIds.Contains(p.Id)).AsNoTracking().ToListAsync();
        //    //existingPlayers = existingPlayers.OrderBy(p => playerIds.IndexOf(p.Id)).ToList();   //reorder to match the order of received list of playerIds
        //    //group.Players = existingPlayers;
        //    var existingPlayers = group.Players.ToList();
        //    var groupMatches = new List<Match>();
        //    for (int i = 0; i < roundRobinScheme.Length; i++)
        //    {
        //        for (int j = 0; j < roundRobinScheme[i].Length; j++)
        //        {
        //            var player1 = existingPlayers[roundRobinScheme[i][j][0] - 1];
        //            var player2 = existingPlayers[roundRobinScheme[i][j][1] - 1];
        //            //ICollection<Player> MatchPlayers = new List<Player>
        //            //{
        //            //    player1, player2
        //            //};
        //            Match match = new Match
        //            {
        //                P1 = player1,
        //                P2 = player2
        //            };
        //            groupMatches.Add(match);
        //            //await _context.Matches.AddAsync(match);
        //            //await _context.SaveChangesAsync();
        //        }
        //    }

        //    //await _context.Groups.AddAsync(group);
        //    //await _context.SaveChangesAsync();
        //    return groupMatches;
        //}

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
