using AutoMapper;
using FluentValidation;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using FootballLeague.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.TeamDtos;

namespace Football_League.BLL.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IStadiumRepository _stadiumRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<TeamSaveDto> _teamSaveDtoValidator;

        public TeamService(ITeamRepository teamRepository, IStadiumRepository stadiumRepository,
                           IMapper mapper, IValidator<TeamSaveDto> teamSaveDtoValidator)
        {
            _teamRepository = teamRepository;
            _stadiumRepository = stadiumRepository;
            _mapper = mapper;
            _teamSaveDtoValidator = teamSaveDtoValidator;
        }

        public async Task<TeamDto> CreateTeamAsync(TeamSaveDto teamSaveDto)
        {
            var validationResult = await _teamSaveDtoValidator.ValidateAsync(teamSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var stadium = await _stadiumRepository.GetByIdAsync(teamSaveDto.StadiumId);
            if (stadium == null)
            {
                throw new KeyNotFoundException($"Stadium with ID {teamSaveDto.StadiumId} not found.");
            }

            var team = _mapper.Map<Team>(teamSaveDto);
            team.Stadium = stadium;

            await _teamRepository.CreateAsync(team);

            return _mapper.Map<TeamDto>(team);
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {id} not found.");
            }

            return _mapper.Map<TeamDto>(team);
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task UpdateTeamAsync(int id, TeamSaveDto teamSaveDto)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {id} not found.");
            }

            var validationResult = await _teamSaveDtoValidator.ValidateAsync(teamSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var stadium = await _stadiumRepository.GetByIdAsync(teamSaveDto.StadiumId);
            if (stadium == null)
            {
                throw new KeyNotFoundException($"Stadium with ID {teamSaveDto.StadiumId} not found.");
            }

            _mapper.Map(teamSaveDto, team);
            team.Stadium = stadium;

            await _teamRepository.UpdateAsync(team);
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {id} not found.");
            }
            await _teamRepository.DeleteAsync(id);
        }
    }

}
