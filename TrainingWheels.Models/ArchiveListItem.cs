using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Data;

namespace TrainingWheels.Models
{
    public class ArchiveListItem
    {
        public int ArchiveId { get; set; }

        public int ActivityId { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public ActivityEntity ActivityEntity { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
