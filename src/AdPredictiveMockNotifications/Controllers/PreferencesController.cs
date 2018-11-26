using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.DomainRepositories;
using DAL.Services;
using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdPredictiveMockSituation.Controllers
{
    //[Authorize(Roles = "Admin, ServiceAccount, etc")] No authorization or authentication present currently
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private static IPreferences _userPrefs;

        public PreferencesController()
        {
            if (_userPrefs == null)
            {
                _userPrefs = new UserPreferencesService();

                //seeding a set of preferences to simulate actual stored data
                _userPrefs.UpdatePreferences(FirstUser());
            }
        }

        // GET api/preferences/
        [HttpGet]
        public IActionResult Get()
        {
            //var allUsersPreferences = _userPrefs.All;
            return Ok("Web API successfully started");
        }

        // GET api/preferences/5
        [HttpGet("{id}")]
        [DisableCors]
        public IActionResult Get(int id)
        {
            return Ok(_userPrefs.GetUserPreferencesById(id));
        }

        // GET api/preferences/allpreferences
        [HttpGet]
        [Route("allPreferences")]
        public IActionResult GetAll()
        {
            var allUsersPreferences = _userPrefs.All;
            return Ok(allUsersPreferences);
        }

        //TODO: Remove the id from the put route if it is not needed
        // PUT api/preferences/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserPreferences preferences)
        {
            //One issue that can occur here is that if the preferences are sent from the front end and are missing
            //data points from the Preferences object, the values will default to true (or false if the default values 
            //are removed from the Preferences Properties).  Front end validation would be required.
            try
            {
                _userPrefs.UpdatePreferences(preferences);
                return Ok(new { message = "User preferences successfully committed", preferences });
            }
            catch (Exception ex)
            {
                //log error
                return BadRequest(new { message = "Invalid or missing preferences data", preferences });//400 status code
            }

        }


        private UserPreferences FirstUser()
        {
            return new UserPreferences()
            {
                UserId = 1,
                UserPrefs = new Preferences()
                {
                    CampaignStatusChangedNotificaiton = true,
                    NewCommentNotificaiton = true,
                    NewReportAvailableNotification = true
                }
            }
            ;
        }
    }
}
