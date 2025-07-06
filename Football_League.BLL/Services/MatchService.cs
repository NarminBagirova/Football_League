using AutoMapper;
using FluentValidation;
using Football_League.BLL.DTOs;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using FootballLeague.BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.BLL.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<MatchDtos.MatchSaveDto> _matchSaveDtoValidator;

        public MatchService(IMatchRepository matchRepository, ITeamRepository teamRepository,
                            IMapper mapper, IValidator<MatchDtos.MatchSaveDto> matchSaveDtoValidator)
        {
            _matchRepository = matchRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _matchSaveDtoValidator = matchSaveDtoValidator;
        }
        public async Task<MatchDtos.MatchDto> CreateMatchAsync(MatchDtos.MatchSaveDto matchSaveDto)
        {
            var validationResult = await _matchSaveDtoValidator.ValidateAsync(matchSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var homeTeam = await _teamRepository.GetByIdAsync(matchSaveDto.HomeTeamId);
            var awayTeam = await _teamRepository.GetByIdAsync(matchSaveDto.AwayTeamId);

            if (homeTeam == null || awayTeam == null)
            {
                throw new KeyNotFoundException("Home or Away team not found.");
            }

            var match = _mapper.Map<Match>(matchSaveDto);

            // Save the match
            await _matchRepository.CreateAsync(match);

            // Update team statistics after the match is created
            await UpdateTeamStatisticsAsync(homeTeam, awayTeam, match);

            // Return match data as a DTO
            return _mapper.Map<MatchDtos.MatchDto>(match);
        }

        // Get match by ID
        public async Task<MatchDtos.MatchDto> GetMatchByIdAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                throw new KeyNotFoundException($"Match with ID {id} not found.");
            }

            return _mapper.Map<MatchDtos.MatchDto>(match);
        }

        // Get all matches
        public async Task<IEnumerable<MatchDtos.MatchDto>> GetAllMatchesAsync()
        {
            var matches = await _matchRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MatchDtos.MatchDto>>(matches);
        }

        // Update a match
        public async Task UpdateMatchAsync(int id, MatchDtos.MatchSaveDto matchSaveDto)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                throw new KeyNotFoundException($"Match with ID {id} not found.");
            }

            var validationResult = await _matchSaveDtoValidator.ValidateAsync(matchSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Update match details
            _mapper.Map(matchSaveDto, match);

            // Save updated match
            await _matchRepository.UpdateAsync(match);

            var homeTeam = await _teamRepository.GetByIdAsync(match.HomeTeamId);
            var awayTeam = await _teamRepository.GetByIdAsync(match.AwayTeamId);
            await UpdateTeamStatisticsAsync(homeTeam, awayTeam, match);
        }

        // Delete a match
        public async Task DeleteMatchAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                throw new KeyNotFoundException($"Match with ID {id} not found.");
            }

            // Delete the match
            await _matchRepository.DeleteAsync(id);
        }

        // Update statistics for both teams after the match
        private async Task UpdateTeamStatisticsAsync(Team homeTeam, Team awayTeam, Match match)
        {
            if (match.HomeGoals > match.AwayGoals)
            {
                homeTeam.Wins++;
                awayTeam.Losses++;
            }
            else if (match.HomeGoals < match.AwayGoals)
            {
                homeTeam.Losses++;
                awayTeam.Wins++;
            }
            else
            {
                homeTeam.Draws++;
                awayTeam.Draws++;
            }
            homeTeam.GoalsFor += match.HomeGoals;
            awayTeam.GoalsFor += match.AwayGoals;
            homeTeam.GoalsAgainst += match.AwayGoals;
            awayTeam.GoalsAgainst += match.HomeGoals;

            await _teamRepository.UpdateAsync(homeTeam);
            await _teamRepository.UpdateAsync(awayTeam);
        }
    }
}


