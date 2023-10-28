using AutoMapper;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Extensions;
using RetroGamingTournament.Models;
using RetroGamingTournament.Repositories;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TournamentScheduling;

namespace RetroGamingTournament.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _repository;
        public TournamentService(IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _mapper = mapper;
            _repository = tournamentRepository;
        }
        public async Task<IEnumerable<GroupGetDetailsResponseDTO>> GroupsGetDetails(IEnumerable<PlayerDTO> players)
        {
            if (players.Count() < 8 ||  players.Count() > 16)
            {
                return null;
            }

            GroupGetDetailsResponseDTO P = new GroupGetDetailsResponseDTO { };
            P.GroupPlayers = new List<PlayerDTO>();
            GroupGetDetailsResponseDTO C = new GroupGetDetailsResponseDTO { };
            C.GroupPlayers = new List<PlayerDTO>();
            GroupGetDetailsResponseDTO Z = new GroupGetDetailsResponseDTO { };
            Z.GroupPlayers = new List<PlayerDTO>();
            GroupGetDetailsResponseDTO S = new GroupGetDetailsResponseDTO { };
            S.GroupPlayers = new List<PlayerDTO>();

            var shuffledPlayers = players.ToList().Shuffle();

            switch (players.Count())
            {
                case 8:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 4;
                    break;
                case 9:
                    P.NumberOfGroupContestants = 3;
                    C.NumberOfGroupContestants = 3;
                    Z.NumberOfGroupContestants = 3;

                    break;
                case 10:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 3;
                    Z.NumberOfGroupContestants = 3;
                    break;
                case 11:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 4;
                    Z.NumberOfGroupContestants = 3;
                    break;
                case 12:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 4;
                    Z.NumberOfGroupContestants = 4;
                    break;
                case 13:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 3;
                    Z.NumberOfGroupContestants = 3;
                    S.NumberOfGroupContestants = 3;
                    break;
                case 14:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 4;
                    Z.NumberOfGroupContestants = 3;
                    S.NumberOfGroupContestants = 3;
                    break;
                case 15:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 4;
                    Z.NumberOfGroupContestants = 4;
                    S.NumberOfGroupContestants = 3;
                    break;
                case 16:
                    P.NumberOfGroupContestants = 4;
                    C.NumberOfGroupContestants = 4;
                    Z.NumberOfGroupContestants = 4;
                    S.NumberOfGroupContestants = 4;
                    break;
                default:
                    throw new ArgumentException();
            }
            var groupP = (shuffledPlayers.Take(P.NumberOfGroupContestants)).ToList();
            foreach (var p in groupP)
            {
                P.GroupPlayers.Add(p);
            }

            var groupC = (shuffledPlayers.Skip(P.NumberOfGroupContestants).Take(C.NumberOfGroupContestants)).ToList();
            foreach (var c in groupC)
            {
                C.GroupPlayers.Add(c);
            }

            if (Z.NumberOfGroupContestants > 0)
            {
                var groupZ = (shuffledPlayers.Skip(P.NumberOfGroupContestants + C.NumberOfGroupContestants).Take(Z.NumberOfGroupContestants));
                foreach (var z in groupZ)
                {
                    Z.GroupPlayers.Add(z);
                }
            }
            if (S.NumberOfGroupContestants > 0)
            {
                var groupS = (shuffledPlayers.Skip(P.NumberOfGroupContestants + C.NumberOfGroupContestants + Z.NumberOfGroupContestants).Take(S.NumberOfGroupContestants));
                foreach (var s in groupS)
                {
                    S.GroupPlayers.Add(s);
                }
            }
            if (players.Count() == 8)
            {

                return new List<GroupGetDetailsResponseDTO> { P, C };
            }
            if (players.Count() >= 9 && players.Count() <= 12)
            {
                return new List<GroupGetDetailsResponseDTO> { P, C, Z };
            }
            else
            {
                return new List<GroupGetDetailsResponseDTO> { P, C, Z, S };
            }
        }
        public int[][][] GetRoundRobin(int numberOfPlayers)
        {
            var schedule = new RoundRobinAlgorithm().GetCalculatedSchedule(numberOfPlayers);
            return schedule;
        }

        public async Task<TournamentGetDetailsResponseDTO> CreateAsync(TournamentCreateRequestDTO tournamentDTO)
        {
            var tournamentEntity = _mapper.Map<Tournament>(tournamentDTO);
            await _repository.Create(tournamentEntity);
            var tournamentDetailsDTO = _mapper.Map<TournamentGetDetailsResponseDTO>(tournamentEntity);
            return tournamentDetailsDTO;

        }

        public Task<IEnumerable<TournamentGetDetailsResponseDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TournamentGetDetailsResponseDTO> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
