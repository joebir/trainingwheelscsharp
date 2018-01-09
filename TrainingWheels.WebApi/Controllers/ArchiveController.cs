using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingWheels.Models;
using TrainingWheels.Services;

namespace TrainingWheels.WebApi.Controllers
{
    [Authorize]
    public class ArchiveController : ApiController
    {
        //Get /api/archive
        public IHttpActionResult GetAll()
        {
            var archiveService = CreateArchiveService();
            var archives = archiveService.GetActivityHistory();
            return Ok(archives);
        }

        // GET /api/archive
        public IHttpActionResult Get(int id)
        {
            var archiveService = CreateArchiveService();
            var todaysArchive = archiveService.GetTodaysArchive();
            if (todaysArchive == null) return NotFound();
            return Ok(todaysArchive);

        }

        public IHttpActionResult Post(ArchiveModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateArchiveService();

            if (!service.CreateArchiveEntry(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete (int id)
        {
            var service = CreateArchiveService();

            if (!service.DeleteArchiveEntry(id))
                return InternalServerError();

            return Ok();
        }

        private ArchiveService CreateArchiveService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var archiveService = new ArchiveService(userID);
            return archiveService;
        }
    }
}
