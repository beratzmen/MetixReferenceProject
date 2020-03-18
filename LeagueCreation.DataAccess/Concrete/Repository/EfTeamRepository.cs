using LeagueCreation.DataAccess.Abstract;
using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueCreation.DataAccess.Concrete.Repository
{
    public class EfTeamRepository : ITeamDal
    {
        private Context context = new Context();
        public bool Add(Team entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                entity.CreateDate = DateTime.Now;
                entity.ChangeDate = DateTime.Now;
                if (context.Team.Any(x => x.Name == entity.Name && x.IsDeleted == false))
                {
                    return false;
                }
                else
                    context.Team.Add(entity);
            }


            return (context.SaveChanges() > 0) ? true : false;
        }

        public bool Delete(int Id)
        {
            var model = context.Team.FirstOrDefault(x => x.Id == Id);
            model.IsDeleted = true;
            model.ChangeDate = DateTime.Now;
            return (context.SaveChanges() > 0) ? true : false;
        }

        public Team Get(int Id)
        {
            return context.Team.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);
        }

        public List<Team> GetAll()
        {
            return context.Team.Where(x => x.IsDeleted == false).OrderByDescending(p => p.Point).ToList();
        }

        public bool Update(Team entity)
        {
            Team teamToUpdate = Get(entity.Id);
            if (!context.Team.Any(x => x.Name == entity.Name && x.IsDeleted == false))
            {
                teamToUpdate.Name = entity.Name;
                teamToUpdate.ChangeDate = DateTime.Now;
            }
            else
                return false;

            return (context.SaveChanges() > 0) ? true : false;
        }
        public bool UpdatePoint(TeamVM entity)
        {
            var homeTeam = Get(entity.Team1Id);
            homeTeam.Point += entity.PointHome;
            homeTeam.ChangeDate = DateTime.Now;

            var awayTeam = Get(entity.Team2Id);
            awayTeam.Point += entity.PointAway;
            awayTeam.ChangeDate = DateTime.Now;

            return (context.SaveChanges() > 0) ? true : false;
        }
    }
}
