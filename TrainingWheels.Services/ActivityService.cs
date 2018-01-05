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
        public ActivityService()
        {
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
            throw new NotImplementedException();
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
                                     Name = e.Name
                                 })
                       .ToList();
            }
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
