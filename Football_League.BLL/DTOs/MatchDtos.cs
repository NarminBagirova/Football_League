using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL.DTOs
{
    public class MatchDtos
    {
        public record MatchDto(int Id, int HomeTeamId, int AwayTeamId, int WeekNumber, int HomeGoals, int AwayGoals, IEnumerable<GoalScorerDto> GoalScorers);
        public record MatchSaveDto(int HomeTeamId, int AwayTeamId, int WeekNumber, int HomeGoals, int AwayGoals, IEnumerable<GoalScorerDto> GoalScorers);
        public record GoalScorerDto(int PlayerId, int GoalsScored);
    }
}
