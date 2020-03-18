using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using System.Collections.Generic;

namespace LeagueCreation.DataAccess.Abstract
{
    public interface ITeamDal
    {
        List<Team> GetAll();
        Team Get(int Id);
        bool Add(Team entity);
        bool Delete(int Id);
        bool Update(Team entity);
        bool UpdatePoint(TeamVM entity);
    }
}
