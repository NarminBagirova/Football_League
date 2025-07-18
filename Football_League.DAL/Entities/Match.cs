﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int WeekNumber { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public ICollection<MatchGoal> MatchGoals { get; set; }
    }
}
