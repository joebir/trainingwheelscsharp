﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Models;

namespace TrainingWheels.Contracts
{
    public interface IArchiveService
    {
        IEnumerable<ArchiveListItem> GetActivityHistory(int id);
        IEnumerable<ArchiveListItem> GetTodaysArchive(int id);
        bool CreateArchiveEntry(ArchiveModel model);
        bool DeleteArchiveEntry(int id);
    }
}
