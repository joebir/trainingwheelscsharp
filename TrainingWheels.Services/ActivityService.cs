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
    public class ActivityService : IActivityService
    {
        private readonly Guid _userId;

        public ActivityService(Guid userId)
        {
            _userId = userId;
        }

        private ActivityEntity GetActivitiesFromDatabase(ApplicationDbContext context, int activityId)
        {
            return
                 context
                    .Activities
                    .SingleOrDefault(
                           e =>
                           e.ActivityId == activityId);
        }

        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new ActivityEntity()
                {
                    ActivityId = model.ActivityId,
                    Name = model.Name,
                    Category = model.Category,
                    Score = model.Score
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ActivityListItem> GetActivities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                     ctx
                         .Activities
                         .Select(
                             e =>
                                 new ActivityListItem()
                                 {
                                     ActivityId = e.ActivityId,
                                     Name = e.Name,
                                     //??
                                     Category = e.Category,
                                 })
                       .ToList();
            }
        }

        public ActivityListItem GetActivityById(int activityId)
        {
            ActivityEntity entity;

            using (var ctx = new ApplicationDbContext())
            {
                entity = GetActivitiesFromDatabase(ctx, activityId);
            }

            if (entity == null) return new ActivityListItem();

            return
                new ActivityListItem
                {
                    ActivityId = entity.ActivityId,
                    Name = entity.Name,
                    Category = entity.Category,
                };
        }

        public bool UpdateActivity(ActivityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var activityId = model.ActivityId;
                var entity = GetActivitiesFromDatabase(ctx, activityId);

                if (entity == null) return false;

                entity.ActivityId = model.ActivityId;
                entity.Name = model.Name;
                entity.Category = model.Category;
                entity.Score = model.Score;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteActivity(int activityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.ActivityId == activityId);

                ctx.Activities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
