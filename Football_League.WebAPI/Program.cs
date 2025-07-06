using Football_League.BLL.Mapping; 
using AutoMapper;
using Football_League.BLL.Services.Interfaces;
using Football_League.BLL.Services;
using Football_League.DAL.Repositories.Interfaces;
using Football_League.DAL.Repositories;
using FootballLeague.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IStadiumService, StadiumService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
