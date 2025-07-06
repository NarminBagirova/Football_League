using Football_League.BLL.DTOs;
using Football_League.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Football_League.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDtos.TeamDto>>> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDtos.TeamDto>> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamDtos.TeamDto>> CreateTeam(TeamDtos.TeamSaveDto teamSaveDto)
        {
            var createdTeam = await _teamService.CreateTeamAsync(teamSaveDto);
            return CreatedAtAction(nameof(GetTeamById), new { id = createdTeam.Id }, createdTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, TeamDtos.TeamSaveDto teamSaveDto)
        {
            await _teamService.UpdateTeamAsync(id, teamSaveDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}