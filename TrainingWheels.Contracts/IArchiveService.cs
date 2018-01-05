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
        IEnumerable<ArchiveModel> GetActivityHistory();
        IEnumerable<ArchiveModel> GetTodaysArchive();
        bool CreateArchiveEntry(ArchiveModel model);
        bool DeleteArchiveEntry(ArchiveModel model);
    }
}
