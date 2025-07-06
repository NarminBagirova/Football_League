document.addEventListener('DOMContentLoaded', () => {
    fetch('https://api.football-league.com/teams') 
        .then(response => response.json())
        .then(teams => {
            const teamsTableBody = document.querySelector('#teams tbody');
            teams.forEach(team => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${team.name}</td>
                    <td>${team.code}</td>
                    <td>${team.wins}</td>
                    <td>${team.losses}</td>
                    <td>${team.goals}</td>
                `;
                teamsTableBody.appendChild(row);
            });
        });

    fetch('https://api.football-league.com/matches')
        .then(response => response.json())
        .then(matches => {
            const matchList = document.querySelector('.match-list');
            matches.forEach(match => {
                const matchItem = document.createElement('div');
                matchItem.classList.add('match-item');
                matchItem.innerHTML = `
                    <h3>${match.homeTeam} vs ${match.awayTeam}</h3>
                    <p>Week: ${match.weekNumber}</p>
                    <p>Score: ${match.homeGoals} - ${match.awayGoals}</p>
                `;
                matchList.appendChild(matchItem);
            });
        });
});
