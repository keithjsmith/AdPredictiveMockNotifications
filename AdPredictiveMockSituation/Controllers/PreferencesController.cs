using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdPredictiveMockSituation.Controllers
{
    //[Authorize(Roles = "Admin, ServiceAccount, etc")] No authorization or authentication present currently
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {

        //no requirement for getAll, explicit posting, or delete functionality at this time

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string preferences)
        {
        }

    }
}
