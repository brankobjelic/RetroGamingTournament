﻿using AutoMapper;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Repositories;

namespace RetroGamingTournament.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<PlayerGetDetailsResponseDTO> CreateAsync(PlayerCreateRequestDTO player)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlayerDTO>> GetAsync()
        {
            var players = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PlayerDTO>>(players);
        }

        public async Task<PlayerDTO> GetDetailsAsync(int id)
        {
            var player = await _repository.Get(id);
            return _mapper.Map<PlayerDTO>(player);
        }
    }
}
