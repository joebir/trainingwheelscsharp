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
                return
                     ctx
                         .Archives
                         .Select(
                             e =>
                                 new ArchiveListItem()
                                 {
                                    ArchiveId = e.ArchiveId,
                                    ActivityId = e.ActivityId,
                                    //Name = e.Name,
                                    //Category e.Category,
                                    CreatedUtc = e.CreatedUtc,
                                 })
                       .ToList();
            }
        }

        public IEnumerable<ArchiveListItem> GetTodaysArchive()
        {
            throw new NotImplementedException();
        }

        public bool CreateArchiveEntry(ArchiveModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteArchiveEntry(ArchiveModel model)
        {
            throw new NotImplementedException();
        }
    }
}
