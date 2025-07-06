using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.TeamDtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface ITeamService
    {
        Task<TeamDto> CreateTeamAsync(TeamSaveDto teamSaveDto);
        Task<TeamDto> GetTeamByIdAsync(int id);
        Task<IEnumerable<TeamDto>> GetAllTeamsAsync();
        Task UpdateTeamAsync(int id, TeamSaveDto teamSaveDto);
        Task DeleteTeamAsync(int id);
    }
}


