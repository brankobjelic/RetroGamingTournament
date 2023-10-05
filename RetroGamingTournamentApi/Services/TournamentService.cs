using AutoMapper;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Extensions;
using RetroGamingTournament.Models;
using System.Collections.Generic;

namespace RetroGamingTournament.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IMapper _mapper;
        public TournamentService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<GroupGetDetailsResponseDTO>> GroupsGetDetails(IEnumerable<PlayerDTO> players)
        {
            if (players.Count() < 8 ||  players.Count() > 16)
            {
                return null;
            }

            Group P = new Group {};
            Group C = new Group {};
            Group Z = new Group {};
            Group S = new Group {};

            players.ToList().Shuffle();

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
            var groupP = (players.Take(P.NumberOfGroupContestants));
            P.GroupPlayers = _mapper.Map<ICollection<TournamentPlayer>>(groupP);
            var groupC = (players.Take(C.NumberOfGroupContestants));
            C.GroupPlayers = _mapper.Map<ICollection<TournamentPlayer>>(groupC);
            if (Z.NumberOfGroupContestants > 0)
            {
                var groupZ = (players.Take(Z.NumberOfGroupContestants));
                Z.GroupPlayers = _mapper.Map<ICollection<TournamentPlayer>>(groupZ);
            }
            if (S.NumberOfGroupContestants > 0)
            {
                var groupS = (players.Take(S.NumberOfGroupContestants));
                Z.GroupPlayers = _mapper.Map<ICollection<TournamentPlayer>>(groupS);
            }
            if (players.Count() == 8)
            {
                var PgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(P);
                var CgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(C);
                return new List<GroupGetDetailsResponseDTO> { PgroupDTO, CgroupDTO };
            }
            if (players.Count() >= 9 && players.Count() <= 12)
            {
                var PgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(P);
                var CgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(C);
                var ZgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(Z);
                return new List<GroupGetDetailsResponseDTO> { PgroupDTO, CgroupDTO, ZgroupDTO };
            }
            else
            {
                var PgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(P);
                var CgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(C);
                var ZgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(Z);
                var SgroupDTO = _mapper.Map<GroupGetDetailsResponseDTO>(S);
                return new List<GroupGetDetailsResponseDTO> { PgroupDTO, CgroupDTO, ZgroupDTO, SgroupDTO };
            }
        }
    }
}
