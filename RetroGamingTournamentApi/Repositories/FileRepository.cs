namespace RetroGamingTournament.Repositories
{
    public class FileRepository : IFileRepository
    {

        public byte[] FileToByteArray(string url)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(url);
            return bytes;
        }
    }
}
