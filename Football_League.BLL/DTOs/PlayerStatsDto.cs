using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL.DTOs
{
    public record PlayerStatsDto(int PlayerId, string PlayerName, string TeamName, int GoalsScored);
}
