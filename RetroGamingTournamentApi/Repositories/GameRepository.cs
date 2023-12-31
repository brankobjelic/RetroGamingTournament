﻿using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Game> _collection;
        public GameRepository(AppDbContext context)
        {
            _context = context;
            _collection = _context.Games;
        }
        public Task<Game> Create(Game game)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> Get(int id)
        {
            var game = await _context.Games.Include(x => x.Tournaments).FirstOrDefaultAsync(x => x.Id == id);
            return game;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var games = await _collection.AsNoTracking().ToListAsync();
            return games;
        }
    }
}
