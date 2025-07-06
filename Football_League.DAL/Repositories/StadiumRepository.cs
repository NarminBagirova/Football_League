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
    public class StadiumRepository : GenericRepository<Stadium>, IStadiumRepository
    {
        private readonly FootballLeagueDbContext _context;

        public StadiumRepository(FootballLeagueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Stadium> GetByIdAsync(int id)
        {
            return await _context.Stadiums.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
