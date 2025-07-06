using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        private readonly FootballLeagueDbContext _context;

        public PlayerRepository(FootballLeagueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Player> GetPlayerByShirtNumberAsync(int teamId, int shirtNumber)
        {
            return await _context.Players
                .FirstOrDefaultAsync(p => p.TeamId == teamId && p.ShirtNumber == shirtNumber);
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId)
        {
            return await _context.Players
                .Where(p => p.TeamId == teamId)
                .ToListAsync();
        }
    }
}
