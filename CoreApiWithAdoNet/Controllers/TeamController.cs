using CoreApiWithAdoNet.Model;
using CoreApiWithAdoNet.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreApiWithAdoNet.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly IOptions<AppSettings> appSettings;

        public TeamController(IOptions<AppSettings> settings)
        {
            appSettings = settings;
        }

        [HttpGet]
        public IActionResult GetAllTeam()
        {
            var result = new DbClient().GetAllTeam(appSettings.Value.DbConnection);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveTeam([FromBody]Team formData)
        {
            var returnData = new Message<Team>();
            var data = new DbClient().SaveTeam(formData, appSettings.Value.DbConnection);
            if (data == "CR_200")
            {
                returnData.IsSuccess = true;
                returnData.InfoMessage = formData.Id == 0 ? "User saved successfully" : "User updated successfully";

            }
            else if (data == "CR_201")
            {
                returnData.IsSuccess = false;
                returnData.InfoMessage = "Team already exists";
            }
            return Ok(returnData);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var returnData = new Message<Team>();
            var data = new DbClient().DeleteUser(id, appSettings.Value.DbConnection);
            if (data == "RC_200")
            {
                returnData.IsSuccess = true;
                returnData.InfoMessage = "User Deleted";
            }
            else if (data == "RC_202")
            {
                returnData.IsSuccess = false;
                returnData.InfoMessage = "Record  not found";
            }
            return Ok(returnData);
        }

    }
}
