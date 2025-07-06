using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.PlayerDtos;

namespace Football_League.BLL.Services.Interfaces
{

    public interface IPlayerService
    {
        Task<PlayerDto> CreatePlayerAsync(PlayerSaveDto playerSaveDto);
        Task<PlayerDto> GetPlayerByIdAsync(int id);
        Task<IEnumerable<PlayerDto>> GetAllPlayersAsync();
        Task UpdatePlayerAsync(int id, PlayerSaveDto playerSaveDto);
        Task DeletePlayerAsync(int id);
    }
}


