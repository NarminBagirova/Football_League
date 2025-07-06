using Football_League.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Repositories.Interfaces
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<IEnumerable<Team>> GetTeamsByStadiumIdAsync(int stadiumId);
        Task<Team> GetTeamWithPlayersAsync(int teamId);
    }
}
