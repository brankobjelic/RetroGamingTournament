using RetroGamingTournament.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace RetroGamingTournament.Services
{
    public class FileService : IFileService
    {
        public readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public byte[] GetAudioFile(string filename)
        {
            string audioPath = "wwwroot/audio/" + filename;
            return _fileRepository.FileToByteArray(audioPath);
        }
    }
}
