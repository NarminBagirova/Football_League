using AutoMapper;
using FluentValidation;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.PlayerDtos;

namespace FootballLeague.BLL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PlayerDtos.PlayerSaveDto> _playerSaveDtoValidator;

        public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository,
                             IMapper mapper, IValidator<PlayerDtos.PlayerSaveDto> playerSaveDtoValidator)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _playerSaveDtoValidator = playerSaveDtoValidator;
        }

        public async Task<PlayerDtos.PlayerDto> CreatePlayerAsync(PlayerDtos.PlayerSaveDto playerSaveDto)
        {
            var validationResult = await _playerSaveDtoValidator.ValidateAsync(playerSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var team = await _teamRepository.GetByIdAsync(playerSaveDto.TeamId);
            if (team == null)
            {
                throw new KeyNotFoundException("Team not found.");
            }

            var player = _mapper.Map<Player>(playerSaveDto);

            await _playerRepository.CreateAsync(player);

            return _mapper.Map<PlayerDtos.PlayerDto>(player);
        }

        public async Task<PlayerDtos.PlayerDto> GetPlayerByIdAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                throw new KeyNotFoundException($"Player with ID {id} not found.");
            }

            return _mapper.Map<PlayerDtos.PlayerDto>(player);
        }

        public async Task<IEnumerable<PlayerDtos.PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlayerDtos.PlayerDto>>(players);
        }

        public async Task UpdatePlayerAsync(int id, PlayerDtos.PlayerSaveDto playerSaveDto)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                throw new KeyNotFoundException($"Player with ID {id} not found.");
            }

            var validationResult = await _playerSaveDtoValidator.ValidateAsync(playerSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _mapper.Map(playerSaveDto, player);

            await _playerRepository.UpdateAsync(player);
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                throw new KeyNotFoundException($"Player with ID {id} not found.");
            }

            await _playerRepository.DeleteAsync(id);
        }
    }
}

