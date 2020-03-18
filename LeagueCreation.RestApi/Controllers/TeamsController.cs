using LeagueCreation.Business;
using LeagueCreation.DataAccess.Concrete.Repository;
using LeagueCreation.Entities;
using LeagueCreation.Entities.dto;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LeagueCreation.RestApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TeamsController : ApiController
    {
        TeamManager _teamService = new TeamManager(new EfTeamRepository());

        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(_teamService.GetAll());
        }

        [HttpGet]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(_teamService.Get(id));
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return JsonConvert.SerializeObject(_teamService.Delete(id));
        }

        [HttpPost]
        public string Post([FromBody]Team entity)
        {
            return JsonConvert.SerializeObject(_teamService.Add(entity));
            //return "ahhaha";
        }

        [HttpPut]
        public string Put([FromBody]Team entity)
        {
            return JsonConvert.SerializeObject(_teamService.Update(entity));
        }

        [HttpPut]
        [Route("api/teams/updatepoint")]
        public string UpdatePoint([FromBody]TeamVM entity)
        {
            return JsonConvert.SerializeObject(_teamService.UpdatePoint(entity));
        }
    }
}
