using Microsoft.AspNetCore.Mvc;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StadiumDtos.StadiumDto>>> GetAllStadiums()
        {
            var stadiums = await _stadiumService.GetAllStadiumsAsync();
            return Ok(stadiums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StadiumDtos.StadiumDto>> GetStadiumById(int id)
        {
            var stadium = await _stadiumService.GetStadiumByIdAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            return Ok(stadium);
        }

        [HttpPost]
        public async Task<ActionResult<StadiumDtos.StadiumDto>> CreateStadium(StadiumDtos.StadiumSaveDto stadiumSaveDto)
        {
            var createdStadium = await _stadiumService.CreateStadiumAsync(stadiumSaveDto);
            return CreatedAtAction(nameof(GetStadiumById), new { id = createdStadium.Id }, createdStadium);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStadium(int id, StadiumDtos.StadiumSaveDto stadiumSaveDto)
        {
            await _stadiumService.UpdateStadiumAsync(id, stadiumSaveDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStadium(int id)
        {
            await _stadiumService.DeleteStadiumAsync(id);
            return NoContent();
        }
    }
}
