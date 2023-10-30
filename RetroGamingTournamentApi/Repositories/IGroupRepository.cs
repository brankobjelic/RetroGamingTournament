using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface IGroupRepository
    {
        public Task<Group> Create(Group group, List<int> players);
        public Task<IEnumerable<Group>> GetAll();
        public Task<Group> Get(int id);
        public Task Delete(Group group);
    }
}
