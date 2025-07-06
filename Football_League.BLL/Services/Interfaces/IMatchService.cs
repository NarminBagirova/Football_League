using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootballLeague.BLL.Services
{
    public interface IMatchService
    {
        Task<MatchDtos.MatchDto> CreateMatchAsync(MatchDtos.MatchSaveDto matchSaveDto);
        Task<MatchDtos.MatchDto> GetMatchByIdAsync(int id);
        Task<IEnumerable<MatchDtos.MatchDto>> GetAllMatchesAsync();
        Task UpdateMatchAsync(int id, MatchDtos.MatchSaveDto matchSaveDto);
        Task DeleteMatchAsync(int id);
    }
}


