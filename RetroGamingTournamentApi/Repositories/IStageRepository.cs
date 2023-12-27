using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface IStageRepository
    {
        public Task<IEnumerable<Stage>> GetAll();
    }
}
