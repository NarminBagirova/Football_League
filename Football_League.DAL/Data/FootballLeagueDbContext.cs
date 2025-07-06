using Football_League.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options)
            : base(options)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchGoal> MatchGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
