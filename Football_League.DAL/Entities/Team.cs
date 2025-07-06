using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }

        public ICollection<Player> Players { get; set; }

        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
    }
}
