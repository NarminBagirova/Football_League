using Microsoft.AspNetCore.Mvc;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDtos.PlayerDto>>> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDtos.PlayerDto>> GetPlayerById(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDtos.PlayerDto>> CreatePlayer(PlayerDtos.PlayerSaveDto playerSaveDto)
        {
            var createdPlayer = await _playerService.CreatePlayerAsync(playerSaveDto);
            return CreatedAtAction(nameof(GetPlayerById), new { id = createdPlayer.Id }, createdPlayer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, PlayerDtos.PlayerSaveDto playerSaveDto)
        {
            await _playerService.UpdatePlayerAsync(id, playerSaveDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}
