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
        // Foreign key to relate archive with Activity
        public int ActivityId { get; set; }
    }
}
