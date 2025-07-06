using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.StadiumDtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface IStadiumService
    {
        Task<StadiumDto> CreateStadiumAsync(StadiumSaveDto stadiumSaveDto);
        Task<StadiumDto> GetStadiumByIdAsync(int id);
        Task<IEnumerable<StadiumDto>> GetAllStadiumsAsync();
        Task UpdateStadiumAsync(int id, StadiumSaveDto stadiumSaveDto);
        Task DeleteStadiumAsync(int id);
    }
}


