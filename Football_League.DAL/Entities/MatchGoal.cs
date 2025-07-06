using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Entities
{
    public class MatchGoal
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int GoalsScored { get; set; }
    }
}
