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
        private readonly Guid _userId;

        public ArchiveService(Guid userId)
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

        public IEnumerable<ArchiveListItem> GetActivityHistory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var archive =
                       ctx
                         .Archives
                         .Where(e => e.Id == _userId)
                         .Select(
                             e =>
                                 new ArchiveListItem()
                                 {
                                     ArchiveId = e.ArchiveId,
                                     ActivityId = e.ActivityId,
                                     CreatedUtc = e.CreatedUtc,
                                 });

                var complete = archive.ToList();

                var activityService = new ActivityService(_userId);

                foreach (var activity in complete)
                {
                    activity.Name = activityService.GetActivityById(activity.ActivityId).Name;
                    activity.Category = activityService.GetActivityById(activity.ActivityId).Category;
                }

                return complete;
            }
        }

        public IEnumerable<ArchiveListItem> GetTodaysArchive()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var activityService = new ActivityService(_userId);

                return
                     ctx
                         .Archives
                         .Where(e => e.CreatedUtc == DateTime.Now.Date && e.Id == _userId)
                         .Select(
                             e =>
                                 new ArchiveListItem()
                                 {
                                     ArchiveId = e.ArchiveId,
                                     ActivityId = e.ActivityId,
                                     Name = activityService.GetActivityById(e.ActivityId).Name,
                                     Category = activityService.GetActivityById(e.ActivityId).Category,
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
                    ActivityId = model.ActivityId,
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
                        .Single(e => e.ArchiveId == id && e.Id == _userId);

                ctx.Archives.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
