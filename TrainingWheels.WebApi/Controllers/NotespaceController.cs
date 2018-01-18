using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TrainingWheels.Models;
using TrainingWheels.Services;

namespace TrainingWheels.WebApi.Controllers
{
    public class NotespaceController : ApiController
    {
        public IHttpActionResult Get()
        {
            var notespaceService = CreateNotespaceService();
            var notespace = notespaceService.GetUser();
            if (notespace == null) return NotFound();
            return Ok(notespace);
        }

        public IHttpActionResult Put(NotespaceModel model)
        {
            model.Id = User.Identity.GetUserId();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNotespaceService();

            if (!service.UpdateNotespace(model))
                return InternalServerError();

            return Ok();
        }

        private NotespaceService CreateNotespaceService()
        {
            var userId = User.Identity.GetUserId();
            var notespaceService = new NotespaceService(userId);
            return notespaceService;
        }
    }
}
