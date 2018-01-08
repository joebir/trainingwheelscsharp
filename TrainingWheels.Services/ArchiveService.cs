using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Contracts;
using TrainingWheels.Data;
using TrainingWheels.Models;

namespace TrainingWheels.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly ApplicationUser _userId;

        public ArchiveService(ApplicationUser userId)
        {
            _userId = userId;
        }


        private ArchiveEntity GetArchiveFromDatabase(ApplicationDbContext context, int archiveId)
        {
            return
                 context
                    .Archives
                    .SingleOrDefault(
                           e =>
                           e.ArchiveId == archiveId);
        }

        public IEnumerable<ArchiveListItem> GetActivityHistory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var activityService = new ActivityService(_userId);

                return
                     ctx
                         .Archives
                         .Where(e => e.ApplicationUser == _userId)
                         .Select(
                             e =>
                                 new ArchiveListItem()
                                 {
                                    ArchiveId = e.ArchiveId,
                                    ActivityId = e.ActivityId,
                                    Name = activityService.GetActivityById(id).Name,
                                    Category = activityService.GetActivityById(id).Category,
                                    CreatedUtc = e.CreatedUtc,
                                 })
                       .ToList();
            }
        }

        public IEnumerable<ArchiveListItem> GetTodaysArchive(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var activityService = new ActivityService(_userId);

                return
                     ctx
                         .Archives
                         .Where(e => e.CreatedUtc == DateTime.Now.Date && e.ApplicationUser == _userId)
                         .Select(
                             e =>
                                 new ArchiveListItem()
                                 {
                                     ArchiveId = e.ArchiveId,
                                     ActivityId = e.ActivityId,
                                     Name = activityService.GetActivityById(id).Name,
                                     Category = activityService.GetActivityById(id).Category,
                                     CreatedUtc = e.CreatedUtc,
                                 })
                       .ToList();
            }
        }

        public bool CreateArchiveEntry(ArchiveModel model)
        {
            var entity =
                new ArchiveEntity()
                {
                    ArchiveId = model.ArchiveId,
                    Id = model.Id,
                    ApplicationUser = model.ApplicationUser,
                    ActivityId = model.ActivityId,
                    ActivityEntity = model.ActivityEntity,
                    CreatedUtc = DateTime.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Archives.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArchiveEntry(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Archives
                        .Single(e => e.ArchiveId == id && e.ApplicationUser == _userId);

                ctx.Archives.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

