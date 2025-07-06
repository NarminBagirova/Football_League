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
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        private readonly FootballLeagueDbContext _context;

        public MatchRepository(FootballLeagueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetMatchesByTeamAsync(int teamId)
        {
            return await _context.Matches
                .Where(m => m.HomeTeamId == teamId || m.AwayTeamId == teamId)
                .ToListAsync();
        }
    }
}
