using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingWheels.Data;
using TrainingWheels.Models;
using TrainingWheels.Services;

namespace TrainingWheels.WebApi.Controllers
{
    [Authorize]
    public class ActivityController : ApiController
    {
        // GET /api/activity
        public IHttpActionResult GetAll()
        {
            var activityService = CreateActivityService();
            var activities = activityService.GetActivities();
            return Ok(activities);
        }

        // GET /api/activity/4
        public IHttpActionResult Get(int id)
        {
            var activityService = CreateActivityService();

            var activity = activityService.GetActivityById(id);

            if (activity == null) return NotFound();

            return Ok(activity);

        }

        public IHttpActionResult Post(ActivityCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.CreateActivity(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ActivityEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.UpdateActivity(model))
                return InternalServerError();

            return Ok();
        }
        
        public IHttpActionResult Delete(int id)
        {
            var service = CreateActivityService();

            if (!service.DeleteActivity(id))
                return InternalServerError();

            return Ok();
        }

        private ActivityService CreateActivityService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var adminId = User.IsInRole("Admin");
            var activityService = new ActivityService(userID);
            return activityService;
        }
        
    }
}
