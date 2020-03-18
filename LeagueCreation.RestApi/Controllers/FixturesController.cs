using LeagueCreation.Business;
using LeagueCreation.DataAccess.Concrete.Repository;
using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LeagueCreation.RestApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FixturesController : ApiController
    {
        FixtureManager _fixtureService = new FixtureManager(new EfFixtureRepository());
        TeamManager _teamService = new TeamManager(new EfTeamRepository());

        [HttpGet]
        [Route("api/fixtures/get/{id}")]
        public string Get(int id = 1)
        {
            var getByWeekResult = JsonConvert.SerializeObject(_fixtureService.GetByWeek(id));
            return getByWeekResult;
        }

        [HttpGet]
        [Route("api/fixtures")]
        public bool Get()
        {
            return _fixtureService.ScoreCheck();
        }

        [HttpDelete]
        //[Route("api/teams/{id}")]
        public string Delete(int id)
        {
            return JsonConvert.SerializeObject(_fixtureService.Delete(id));
        }

        [HttpPost]
        public string Post([FromBody] List<Team> entity)
        {
            return JsonConvert.SerializeObject(_fixtureService.Add(entity));
        }

        [HttpPut]
        public string Put([FromBody]Fixture entity)
        {
            if (_fixtureService.Update(entity))
            {
                TeamVM tvm = new TeamVM();
                tvm.Team1Id = entity.Home;
                tvm.Team2Id = entity.Away;
                tvm.Team1Score = entity.HomeScore;
                tvm.Team2Score = entity.AwayScore;
                _teamService.UpdatePoint(tvm);
            }
            return string.Empty;
        }
    }
}

