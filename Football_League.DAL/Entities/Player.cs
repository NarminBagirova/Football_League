using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int GoalsScored { get; set; }
        public int ShirtNumber { get; set; }
    }
}
