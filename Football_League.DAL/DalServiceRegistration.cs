using Microsoft.Extensions.DependencyInjection;
using Football_League.DAL.Repositories.Interfaces;
using Football_League.DAL.Repositories;

namespace Football_League.DAL
{
    public static class DalServiceRegistration
    {
        public static void AddDalServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IStadiumRepository, StadiumRepository>();
        }
    }
}
