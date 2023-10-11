using static System.Net.Mime.MediaTypeNames;

namespace RetroGamingTournament.Repositories
{
    public interface IFileRepository
    {
        byte[] FileToByteArray(string url);
    }
}
