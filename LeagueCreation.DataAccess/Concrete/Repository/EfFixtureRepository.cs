using LeagueCreation.DataAccess.Abstract;
using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using System.Collections.Generic;
using System.Linq;

namespace LeagueCreation.DataAccess.Concrete.Repository
{
    public class EfFixtureRepository : IFixtureDal
    {
        private Context context = new Context();

        public bool Add(Fixture entity)
        {
            context.Fixture.Add(entity);
            return (context.SaveChanges() > 0) ? true : false;
        }
        public bool AddRange(List<Fixture> entityList)
        {
            context.Fixture.AddRange(entityList);
            return (context.SaveChanges() > 0) ? true : false;
        }

        public Fixture Get(int id)
        {
            return context.Fixture.FirstOrDefault(x => x.Id == id);
        }

        public List<Fixture> GetAll()
        {
            return context.Fixture.ToList();
        }
        public bool Delete(int Id)
        {
            var model = context.Fixture.Where(x => x.Id == Id).FirstOrDefault();
            context.Fixture.Remove(model);
            return (context.SaveChanges() > 0) ? true : false;
        }
        public bool Update(Fixture entity)
        {
            var fixture = Get(entity.Id);
            fixture.HomeScore = entity.HomeScore;
            fixture.AwayScore = entity.AwayScore;
            return (context.SaveChanges() > 0) ? true : false;
        }
        public List<FixtureVM> GetByWeek(int week)
        {
            var getByWeekResult = (from c in context.Fixture
                                   join t1 in context.Team on c.Home equals t1.Id
                                   join t2 in context.Team on c.Away equals t2.Id
                                   where c.Week == week
                                   select new FixtureVM()
                                   {
                                       Id = c.Id,
                                       Home = t1.Name,
                                       HomeId = t1.Id,
                                       Away = t2.Name,
                                       AwayId = t2.Id,
                                       HomeScore = c.HomeScore,
                                       AwayScore = c.AwayScore,
                                       PointHome = t1.Point,
                                       PointAway = t2.Point,
                                       Week = c.Week
                                   }).ToList();
            return getByWeekResult;
        }

        public bool AllDelete()
        {
            var model = context.Fixture.ToList();
            context.Fixture.RemoveRange(model);
            context.SaveChanges();
            return true;
        }

        public bool ScoreCheck()
        {
            return context.Fixture.Any(x => x.HomeScore > 0 || x.AwayScore > 0);
        }
    }
}
