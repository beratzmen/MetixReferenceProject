using LeagueCreation.DataAccess.Abstract;
using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using System.Collections.Generic;

namespace LeagueCreation.Business
{
    public class TeamManager
    {
        ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public bool Add(Team entity)
        {
            return _teamDal.Add(entity);
        }
        public bool Delete(int Id)
        {
            return _teamDal.Delete(Id);
        }
        public Team Get(int Id)
        {
            return _teamDal.Get(Id);
        }
        public List<Team> GetAll()
        {
            return _teamDal.GetAll();
        }
        public bool Update(Team entity)
        {
            return _teamDal.Update(entity);
        }
        public List<Team> UpdatePoint(TeamVM entity)
        {
            if (entity.Team1Score > entity.Team2Score)
            {
                entity.PointHome = 1;
                entity.PointAway = -1;
                _teamDal.UpdatePoint(entity);
            }
            else if (entity.Team2Score > entity.Team1Score)
            {
                entity.PointAway = 1;
                entity.PointHome = -1;
                _teamDal.UpdatePoint(entity);
            }
            else
            {
                // Beraberlik sıfır puan
            }
            return GetAll();
        }
    }
}
