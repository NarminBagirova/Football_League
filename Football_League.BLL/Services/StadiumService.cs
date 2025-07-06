using AutoMapper;
using FluentValidation;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.StadiumDtos;


namespace FootballLeague.BLL.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<StadiumDtos.StadiumSaveDto> _stadiumSaveDtoValidator;

        public StadiumService(IStadiumRepository stadiumRepository, IMapper mapper,
                              IValidator<StadiumDtos.StadiumSaveDto> stadiumSaveDtoValidator)
        {
            _stadiumRepository = stadiumRepository;
            _mapper = mapper;
            _stadiumSaveDtoValidator = stadiumSaveDtoValidator;
        }

        public async Task<StadiumDtos.StadiumDto> CreateStadiumAsync(StadiumDtos.StadiumSaveDto stadiumSaveDto)
        {
            var validationResult = await _stadiumSaveDtoValidator.ValidateAsync(stadiumSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var stadium = _mapper.Map<Stadium>(stadiumSaveDto);

            await _stadiumRepository.CreateAsync(stadium);

            return _mapper.Map<StadiumDtos.StadiumDto>(stadium);
        }

        public async Task<StadiumDtos.StadiumDto> GetStadiumByIdAsync(int id)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
            {
                throw new KeyNotFoundException($"Stadium with ID {id} not found.");
            }

            return _mapper.Map<StadiumDtos.StadiumDto>(stadium);
        }

        public async Task<IEnumerable<StadiumDtos.StadiumDto>> GetAllStadiumsAsync()
        {
            var stadiums = await _stadiumRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StadiumDtos.StadiumDto>>(stadiums);
        }

        public async Task UpdateStadiumAsync(int id, StadiumDtos.StadiumSaveDto stadiumSaveDto)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
            {
                throw new KeyNotFoundException($"Stadium with ID {id} not found.");
            }

            var validationResult = await _stadiumSaveDtoValidator.ValidateAsync(stadiumSaveDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _mapper.Map(stadiumSaveDto, stadium);

            await _stadiumRepository.UpdateAsync(stadium);
        }

        public async Task DeleteStadiumAsync(int id)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
            {
                throw new KeyNotFoundException($"Stadium with ID {id} not found.");
            }

            await _stadiumRepository.DeleteAsync(id);
        }
    }
}


