using FluentValidation;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using Football_League.BLL.Services;
using Football_League.BLL.Validators;
using Football_League.DAL.Repositories.Interfaces;
using Football_League.DAL.Repositories;
using FootballLeague.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL
{
    public static class BLLServiceRegistration
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerService, PlayerService>();

            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            services.AddScoped<IValidator<MatchDtos.MatchSaveDto>, MatchSaveDtoValidator>();
            services.AddScoped<IValidator<TeamDtos.TeamSaveDto>, TeamSaveDtoValidator>();
        }
    }
}

