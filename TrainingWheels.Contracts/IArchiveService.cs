using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Models;

namespace TrainingWheels.Contracts
{
    public interface IArchiveService
    {
        ICollection<ActivityListItem> GetActivityHistory();
        ArchiveModel GetTodaysArchive(int date);
        bool RefreshArchive(ArchiveModel model);
    }
}
