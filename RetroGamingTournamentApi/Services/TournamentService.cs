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
        private readonly IStageRepository _stageRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        public TournamentService(IMapper mapper, ITournamentRepository tournamentRepository, IGroupRepository groupRepository, IStageRepository stageRepository, IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _mapper = mapper;
            _repository = tournamentRepository;
            _groupRepository = groupRepository;
            _stageRepository = stageRepository;
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Group>> CreateTournamentGroups(ICollection<int> tournamentPlayersIds)
        {
            if (tournamentPlayersIds.Count() < 8 || tournamentPlayersIds.Count() > 16)
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

            var shuffledPlayers = tournamentPlayersIds.ToList().Shuffle();

            switch (tournamentPlayersIds.Count())
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
            foreach (var p in groupP)
            {
                P.Players.Add(await _playerRepository.Get(p));
            }

            var groupC = (shuffledPlayers.Skip(P.NumberOfGroupContestants).Take(C.NumberOfGroupContestants));
            List<int> groupCPlayerIds = new List<int>();
            foreach (var c in groupC)
            {
                groupCPlayerIds.Add(c);
            }
            foreach (var c in groupC)
            {
                C.Players.Add(await _playerRepository.Get(c));
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
                foreach (var z in groupZ)
                {
                    Z.Players.Add(await _playerRepository.Get(z));
                }
            }
            if (S.NumberOfGroupContestants > 0)
            {
                var groupS = (shuffledPlayers.Skip(P.NumberOfGroupContestants + C.NumberOfGroupContestants + Z.NumberOfGroupContestants).Take(S.NumberOfGroupContestants));
                foreach (var s in groupS)
                {
                    groupSPlayerIds.Add(s);
                }
                foreach (var s in groupS)
                {
                    S.Players.Add(await _playerRepository.Get(s));
                }
            }
            var pRoundRobin = GetRoundRobin(P.NumberOfGroupContestants);
            var cRoundRobin = GetRoundRobin(C.NumberOfGroupContestants);

            if (tournamentPlayersIds.Count() == 8)
            {
                return new List<Group> { P, C };
            }


            if (tournamentPlayersIds.Count() >= 9 && tournamentPlayersIds.Count() <= 12)
            {
                var zRoundRobin = GetRoundRobin(Z.NumberOfGroupContestants);
                return new List<Group> { P, C, Z };
            }
            else
            {
                var zRoundRobin = GetRoundRobin(Z.NumberOfGroupContestants);
                var sRoundRobin = GetRoundRobin(S.NumberOfGroupContestants);
                return new List<Group> { P, C, Z, S };
            }
        }
        public int[][][] GetRoundRobin(int numberOfPlayers)
        {
            var schedule = new RoundRobinAlgorithm().GetCalculatedSchedule(numberOfPlayers);
            return schedule;
        }

        public async Task<TournamentGetDetailsResponseDTO> Create(TournamentCreateRequestDTO tournamentDTO)
        {
            IEnumerable<Stage> predefinedStages = new List<Stage>();
            predefinedStages = await _stageRepository.GetAll();
            var groupStage = predefinedStages.FirstOrDefault(s => s.Name == "GroupStage");
            var last8 = predefinedStages.FirstOrDefault(s => s.Name == "Last8");
            var semiFinal = predefinedStages.FirstOrDefault(s => s.Name == "SemiFinal");
            var final = predefinedStages.FirstOrDefault(s => s.Name == "Final");
            var thirdPlaceMatch = predefinedStages.FirstOrDefault(s => s.Name == "ThirdPlaceMatch");
            var rankingPlay5_8 = predefinedStages.FirstOrDefault(s => s.Name == "RankingPlay5-8");
            var RankingPlay9_10 = predefinedStages.FirstOrDefault(s => s.Name == "RankingPlay9-10");
            var RankingPlay9_11 = predefinedStages.FirstOrDefault(s => s.Name == "RankingPlay9-11");
            var RankingPlay9_12 = predefinedStages.FirstOrDefault(s => s.Name == "RankingPlay9-12");

            var numberOfPlayers = tournamentDTO.TournamentPlayersIds.Count();

            var tournamentEntity = _mapper.Map<Tournament>(tournamentDTO);
            tournamentEntity.Players = new List<Player>();
            foreach(int playerId in tournamentDTO.TournamentPlayersIds)
            {
                tournamentEntity.Players.Add(await _playerRepository.Get(playerId));
            }
            tournamentEntity.IsActive = true;
            tournamentEntity.Stages = new List<Stage>();
            tournamentEntity.Game = new Game();
            tournamentEntity.Game = await _gameRepository.Get(tournamentDTO.GameId);
            tournamentEntity.Groups = new List<Group>();

            if(tournamentEntity.Game.GameType.Equals('A'))
            {
                switch (numberOfPlayers)
                {
                    case 8:
                    case 9:
                        tournamentEntity.Stages = new List<Stage>() { groupStage, last8, semiFinal, final, thirdPlaceMatch, rankingPlay5_8};
                        break;
                    case 10:
                        tournamentEntity.Stages.Add(groupStage);
                        tournamentEntity.Stages.Add(last8);
                        tournamentEntity.Stages.Add(semiFinal);
                        tournamentEntity.Stages.Add(thirdPlaceMatch);
                        tournamentEntity.Stages.Add(final);
                        tournamentEntity.Stages.Add(rankingPlay5_8);
                        tournamentEntity.Stages.Add(RankingPlay9_10);
                        break;
                    case 11:
                        tournamentEntity.Stages.Add(groupStage);
                        tournamentEntity.Stages.Add(last8);
                        tournamentEntity.Stages.Add(semiFinal);
                        tournamentEntity.Stages.Add(thirdPlaceMatch);
                        tournamentEntity.Stages.Add(final);
                        tournamentEntity.Stages.Add(rankingPlay5_8);
                        tournamentEntity.Stages.Add(RankingPlay9_11);
                        break;
                    case 12:
                        tournamentEntity.Stages.Add(groupStage);
                        tournamentEntity.Stages.Add(last8);
                        tournamentEntity.Stages.Add(semiFinal);
                        tournamentEntity.Stages.Add(thirdPlaceMatch);
                        tournamentEntity.Stages.Add(final);
                        tournamentEntity.Stages.Add(rankingPlay5_8);
                        tournamentEntity.Stages.Add(RankingPlay9_12);
                        break;
                }
                var groups  = await CreateTournamentGroups(tournamentDTO.TournamentPlayersIds);
                tournamentEntity.Groups = groups.ToList();
                foreach (Group group in tournamentEntity.Groups)
                {
                    var groupRoundRobin = GetRoundRobin(group.NumberOfGroupContestants);
                    group.Matches = CreateGroupMatches(group, groupRoundRobin).ToList();
                }
            }
            var createdTournament = await _repository.Create(tournamentEntity);
            var tournamentDetailsDTO = _mapper.Map<TournamentGetDetailsResponseDTO>(createdTournament);
            return tournamentDetailsDTO;
        }
  
        public IEnumerable<Match> CreateGroupMatches(Group group, int[][][] roundRobinScheme)
        {
            var existingPlayers = group.Players.ToList();
            var groupMatches = new List<Match>();
            for (int i = 0; i < roundRobinScheme.Length; i++)
            {
                for (int j = 0; j < roundRobinScheme[i].Length; j++)
                {
                    var player1 = existingPlayers[roundRobinScheme[i][j][0] - 1];
                    var player2 = existingPlayers[roundRobinScheme[i][j][1] - 1];
                    Match match = new Match
                    {
                        P1 = player1,
                        P2 = player2
                    };
                    groupMatches.Add(match);
                }
            }
            return groupMatches;
        }

        public Task<IEnumerable<TournamentGetDetailsResponseDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TournamentGetDetailsResponseDTO> GetDetailsAsync(int id)
        {
            var tournament = await _repository.Get(id);
            TournamentGetDetailsResponseDTO tournamentDTO = _mapper.Map<Tournament, TournamentGetDetailsResponseDTO>(tournament); 
            return tournamentDTO;
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
