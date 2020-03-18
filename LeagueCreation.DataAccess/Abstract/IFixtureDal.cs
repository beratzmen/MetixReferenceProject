using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using System.Collections.Generic;

namespace LeagueCreation.DataAccess.Abstract
{
    public interface IFixtureDal
    {
        List<Fixture> GetAll();
        Fixture Get(int id);
        bool Add(Fixture entity);
        bool AddRange(List<Fixture> entityList);
        bool Delete(int Id);
        bool Update(Fixture entity);
        List<FixtureVM> GetByWeek(int week);
        bool AllDelete();
        bool ScoreCheck();
    }
}
