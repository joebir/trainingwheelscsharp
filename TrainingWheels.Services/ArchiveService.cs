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

                var archives =
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
                                 })
                       .ToList();

                List<ArchiveListItem> toReturn = new List<ArchiveListItem>();

                foreach (ArchiveListItem archive in archives)
                {
                    if (archive.CreatedUtc.Date == DateTime.Now.Date)
                    {
                        archive.Name = activityService.GetActivityById(archive.ActivityId).Name;
                        archive.Category = activityService.GetActivityById(archive.ActivityId).Category;
                        toReturn.Add(archive);
                    }
                }

                return toReturn;
            }
        }

        public bool CreateArchiveEntry(int activityId)
        {
            var entity =
                new ArchiveEntity()
                {
                    Id = _userId,
                    ActivityId = activityId,
                    CreatedUtc = DateTime.Now,
                };

            using (var ctx = new ApplicationDbContext())
            {
                var activity = ctx.Activities.SingleOrDefault(e => entity.ActivityId == e.ActivityId);

                if (activity.Category == 1)
                        ctx.Users.SingleOrDefault(e => _userId == Guid.Parse(e.Id)).HnWScore += activity.Score;
                else if (activity.Category == 2)
                    ctx.Users.SingleOrDefault(e => _userId == Guid.Parse(e.Id)).HygScore += activity.Score;
                else if (activity.Category == 3)
                    ctx.Users.SingleOrDefault(e => _userId == Guid.Parse(e.Id)).FinScore += activity.Score;
                else if (activity.Category == 4)
                    ctx.Users.SingleOrDefault(e => _userId == Guid.Parse(e.Id)).SocScore += activity.Score;
                else if (activity.Category == 5)
                    ctx.Users.SingleOrDefault(e => _userId == Guid.Parse(e.Id)).CnOScore += activity.Score;

                ctx.Archives.Add(entity);
                return ctx.SaveChanges() == 2;
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
