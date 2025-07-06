using AutoMapper;
using Football_League.BLL.DTOs;
using Football_League.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.MatchDtos;

namespace Football_League.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stadium, StadiumDtos.StadiumDto>().ReverseMap();
            CreateMap<StadiumDtos.StadiumSaveDto, Stadium>().ReverseMap();

            CreateMap<Team, TeamDtos.TeamDto>().ReverseMap();
            CreateMap<TeamDtos.TeamSaveDto, Team>().ReverseMap();

            CreateMap<Player, PlayerDtos.PlayerDto>().ReverseMap();
            CreateMap<PlayerDtos.PlayerSaveDto, Player>().ReverseMap();

            CreateMap<Match, MatchDtos.MatchDto>()
                .ForMember(dest => dest.GoalScorers, opt => opt.MapFrom(src => src.MatchGoals.Select(mg => new GoalScorerDto(mg.PlayerId, mg.GoalsScored))))
                .ReverseMap();

            CreateMap<Player, PlayerStatsDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ReverseMap();
        }
    }
}
