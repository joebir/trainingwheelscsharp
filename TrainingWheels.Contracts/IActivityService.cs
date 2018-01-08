using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Models;

namespace TrainingWheels.Contracts
{
    public interface IActivityService
    {
        IEnumerable<ActivityListItem> GetActivities();
        bool CreateActivity(ActivityCreate model);
        bool UpdateActivity(ActivityEdit model);
        bool DeleteActivity(int activityId);
    }
}
