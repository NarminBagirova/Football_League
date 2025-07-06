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
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly FootballLeagueDbContext _context;

        public TeamRepository(FootballLeagueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetTeamsByStadiumIdAsync(int stadiumId)
        {
            return await _context.Teams
                .Where(t => t.StadiumId == stadiumId)
                .ToListAsync();
        }

        public async Task<Team> GetTeamWithPlayersAsync(int teamId)
        {
            return await _context.Teams
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == teamId);
        }

    }
}
