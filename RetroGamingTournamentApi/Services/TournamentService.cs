using AutoMapper;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Extensions;
using RetroGamingTournament.Models;
using RetroGamingTournament.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TournamentScheduling;
using Group = RetroGamingTournament.Models.Group;
using Match = RetroGamingTournament.Models.Match;

namespace RetroGamingTournament.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _repository;
        private readonly IGroupRepository _groupRepository;
        public TournamentService(IMapper mapper, ITournamentRepository tournamentRepository, IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _repository = tournamentRepository;
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<GroupGetDetailsResponseDTO>> GroupsGetDetails(DrawRequestDTO drawRequestDTO)
        {
            if (drawRequestDTO.TournamentPlayersIds.Count() < 8 || drawRequestDTO.TournamentPlayersIds.Count() > 16)
            {
                return null;
            }

            Group P = new Group();
            P.Players = new List<Player>();
            P.Matches = new List<Match>();
            Group C = new Group();
            C.Players = new List<Player>();
            C.Matches = new List<Match>();
            Group Z = new Group();
            Z.Players = new List<Player>();
            Z.Matches = new List<Match>();
            Group S = new Group();
            S.Players = new List<Player>();
            S.Matches = new List<Match>();

            P.Name = nameof(P);
            C.Name = nameof(C);
            Z.Name = nameof(Z);
            S.Name = nameof(S);
            P.TournamentId = drawRequestDTO.TournamentId;
            C.TournamentId = drawRequestDTO.TournamentId;
            Z.TournamentId = drawRequestDTO.TournamentId;
            S.TournamentId = drawRequestDTO.TournamentId;
            P.Tournament = await  _repository.Get(drawRequestDTO.TournamentId);
            C.Tournament = await  _repository.Get(drawRequestDTO.TournamentId);
            Z.Tournament = await  _repository.Get(drawRequestDTO.TournamentId);
            S.Tournament = await  _repository.Get(drawRequestDTO.TournamentId);

            var shuffledPlayers = drawRequestDTO.TournamentPlayersIds.ToList().Shuffle();

            switch (drawRequestDTO.TournamentPlayersIds.Count())
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
            var groupP = (shuffledPlayers.Take(P.NumberOfGroupContestants));
            List<int> groupPPlayerIds = new List<int>();
            foreach (var p in groupP)
            {
                groupPPlayerIds.Add(p);
            }

            var groupC = (shuffledPlayers.Skip(P.NumberOfGroupContestants).Take(C.NumberOfGroupContestants));
            List<int> groupCPlayerIds = new List<int>();
            foreach (var c in groupC)
            {
                groupCPlayerIds.Add(c);
            }

                List<int> groupZPlayerIds = new List<int>();
                List<int> groupSPlayerIds = new List<int>();
            if (Z.NumberOfGroupContestants > 0)
            {
                var groupZ = (shuffledPlayers.Skip(P.NumberOfGroupContestants + C.NumberOfGroupContestants).Take(Z.NumberOfGroupContestants));
                foreach (var z in groupZ)
                {
                    groupZPlayerIds.Add(z);
                }
            }
            if (S.NumberOfGroupContestants > 0)
            {
                var groupS = (shuffledPlayers.Skip(P.NumberOfGroupContestants + C.NumberOfGroupContestants + Z.NumberOfGroupContestants).Take(S.NumberOfGroupContestants));
                foreach (var s in groupS)
                {
                    groupSPlayerIds.Add(s);
                }
            }
            var pRoundRobin = GetRoundRobin(P.NumberOfGroupContestants);
            var cRoundRobin = GetRoundRobin(C.NumberOfGroupContestants);

            if (drawRequestDTO.TournamentPlayersIds.Count() == 8)
            {
                await _groupRepository.Create(P, groupPPlayerIds, pRoundRobin);
                await _groupRepository.Create(C, groupCPlayerIds, cRoundRobin);
                var pDTO = _mapper.Map<GroupGetDetailsResponseDTO>(P);
                var cDTO = _mapper.Map<GroupGetDetailsResponseDTO>(C);

                return new List<GroupGetDetailsResponseDTO> { pDTO, cDTO };
            }


            if (drawRequestDTO.TournamentPlayersIds.Count() >= 9 && drawRequestDTO.TournamentPlayersIds.Count() <= 12)
            {
                var zRoundRobin = GetRoundRobin(Z.NumberOfGroupContestants);
                await _groupRepository.Create(P, groupPPlayerIds, pRoundRobin);
                await _groupRepository.Create(C, groupCPlayerIds, cRoundRobin);
                await _groupRepository.Create(Z, groupZPlayerIds, zRoundRobin);
                var pDTO = _mapper.Map<GroupGetDetailsResponseDTO>(P);
                var cDTO = _mapper.Map<GroupGetDetailsResponseDTO>(C);
                var zDTO = _mapper.Map<GroupGetDetailsResponseDTO>(Z);
                return new List<GroupGetDetailsResponseDTO> { pDTO, cDTO, zDTO };
            }
            else
            {
                var zRoundRobin = GetRoundRobin(Z.NumberOfGroupContestants);
                var sRoundRobin = GetRoundRobin(S.NumberOfGroupContestants);
                await _groupRepository.Create(P, groupPPlayerIds, pRoundRobin);
                await _groupRepository.Create(C, groupCPlayerIds, cRoundRobin);
                await _groupRepository.Create(Z, groupZPlayerIds, zRoundRobin);
                await _groupRepository.Create(S, groupSPlayerIds, sRoundRobin);
                var pDTO = _mapper.Map<GroupGetDetailsResponseDTO>(P);
                var cDTO = _mapper.Map<GroupGetDetailsResponseDTO>(C);
                var zDTO = _mapper.Map<GroupGetDetailsResponseDTO>(Z);
                var sDTO = _mapper.Map<GroupGetDetailsResponseDTO>(S);
                return new List<GroupGetDetailsResponseDTO> { pDTO, cDTO, zDTO, sDTO };
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
            tournamentEntity.IsActive = true;
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

        public async Task<IEnumerable<TournamentGetDetailsResponseDTO>> GetByEventIdAsync(int id)
        {
            var tournaments = await _repository.GetByEventId(id);
            IEnumerable<TournamentGetDetailsResponseDTO> tournamentsDTO = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentGetDetailsResponseDTO>>(tournaments);
            return tournamentsDTO;
        }
    }
}
