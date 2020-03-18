using LeagueCreation.DataAccess.Abstract;
using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueCreation.Business
{
    public class FixtureManager
    {
        IFixtureDal _fixtureDal;
        public FixtureManager(IFixtureDal fixtureDal)
        {
            _fixtureDal = fixtureDal;
        }

        public void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static List<Fixture> ComputeFixtures(List<Team> listTeam)
        {
            var result = new List<Fixture>();

            var numberOfRounds = (listTeam.Count - 1);
            var numberOfMatchesInARound = listTeam.Count / 2;

            var teams = new List<Team>();

            teams.AddRange(listTeam.Skip(numberOfMatchesInARound).Take(numberOfMatchesInARound));
            teams.AddRange(listTeam.Skip(1).Take(numberOfMatchesInARound - 1).ToArray().Reverse());

            var numberOfTeams = teams.Count;

            for (var roundNumber = 0; roundNumber < numberOfRounds; roundNumber++)
            {
                var round = new List<Fixture>();
                //round.Id = roundNumber + 1;
                var teamIdx = roundNumber % numberOfTeams;

                round.Add(new Fixture() { Week = Convert.ToInt16(roundNumber + 1), Home = teams[teamIdx].Id, Away = listTeam[0].Id });

                for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                {
                    var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                    var secondTeamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                    round.Add(new Fixture() { Week = Convert.ToInt16(roundNumber + 1), Home = teams[firstTeamIndex].Id, Away = teams[secondTeamIndex].Id });
                }

                round.ForEach(p => result.Add(p));
            }

            return result;
        }


        public bool Add(List<Team> listTeam)
        {
            Shuffle(listTeam);
            var fixture = ComputeFixtures(listTeam);
            //tümkayıtlar silinecek   
            _fixtureDal.AllDelete();
            return _fixtureDal.AddRange(fixture);
        }
        public List<Fixture> GetAll()
        {
            return _fixtureDal.GetAll();
        }
        public Fixture Get(int Id)
        {
            return _fixtureDal.Get(Id);
        }
        public bool Delete(int Id)
        {
            return _fixtureDal.Delete(Id);
        }
        public bool Update(Fixture entity)
        {
            return _fixtureDal.Update(entity);
        }
        public List<FixtureVM> GetByWeek(int week)
        {
            var a = _fixtureDal.GetByWeek(week);
            
            return a;
        }
        public bool ScoreCheck()
        {
            return _fixtureDal.ScoreCheck();
        }
    }
}
