using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingWheels.Data;

namespace TrainingWheels.Models
{
    public class ArchiveModel
    {
        public int ArchiveId { get; set; }

        // Foreign key to relate archive with user
        public Guid Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        // Foreign key to relate archive with Activity
        public int ActivityId { get; set; }

        public ActivityEntity ActivityEntity { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
