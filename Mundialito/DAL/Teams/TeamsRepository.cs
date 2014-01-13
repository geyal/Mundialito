﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mundialito.Models;

namespace Mundialito.DAL.Teams
{
    public class TeamsRepository : GenericRepository<Team>,ITeamsRepository
    {

        public TeamsRepository()
            : base(new MundialitoContext())
        {
        }

        #region Implementation of ITeamsRepository

        public IEnumerable<Team> GetTeams()
        {
            return Get();
        }

        public IEnumerable<Game> GetTeamGames(int teamId)
        {
            return Context.Games.Where(game => game.HomeTeam.TeamId == teamId || game.AwayTeam.TeamId == teamId).Include(game => game.AwayTeam).Include(game => game.HomeTeam).Include(game => game.Stadium);
        }

        public Team GetTeam(int teamId)
        {
            return GetByID(teamId);
        }

        public Team InsertTeam(Team team)
        {
            return Insert(team);
        }

        public void DeleteTeam(int teamId)
        {
            Delete(teamId);
        }

        public void UpdateTeam(Team team)
        {
            Update(team);
        }
       
        #endregion
       
    }
}