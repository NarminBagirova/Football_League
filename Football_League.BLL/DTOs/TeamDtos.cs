using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.StadiumDtos;

namespace Football_League.BLL.DTOs
{
    public class TeamDtos
    {
        public record TeamDto(int Id, string Name, int Code, int Wins, int Draws, int Losses, int GoalsFor, int GoalsAgainst, StadiumDto Stadium);
        public record TeamSaveDto(string Name, int Code, int StadiumId);
    }
}
