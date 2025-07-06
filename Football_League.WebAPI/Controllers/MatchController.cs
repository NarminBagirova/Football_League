using Microsoft.AspNetCore.Mvc;
using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballLeague.BLL.Services;

namespace Football_League.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDtos.MatchDto>>> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDtos.MatchDto>> GetMatchById(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        [HttpPost]
        public async Task<ActionResult<MatchDtos.MatchDto>> CreateMatch(MatchDtos.MatchSaveDto matchSaveDto)
        {
            var createdMatch = await _matchService.CreateMatchAsync(matchSaveDto);
            return CreatedAtAction(nameof(GetMatchById), new { id = createdMatch.Id }, createdMatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, MatchDtos.MatchSaveDto matchSaveDto)
        {
            await _matchService.UpdateMatchAsync(id, matchSaveDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteMatchAsync(id);
            return NoContent();
        }
    }
}
