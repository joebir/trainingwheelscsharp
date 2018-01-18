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
        IEnumerable<ArchiveListItem> GetActivityHistory();
        IEnumerable<ArchiveListItem> GetTodaysArchive();
        bool CreateArchiveEntry(int activityId);
        bool DeleteArchiveEntry(int archiveId);
    }
}
