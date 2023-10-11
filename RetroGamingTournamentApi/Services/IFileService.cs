using System;

namespace RetroGamingTournament.Services
{
    public interface IFileService
    {
        byte[] GetAudioFile(string filename);
    }
}
