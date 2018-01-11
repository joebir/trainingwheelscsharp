using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWheels.Data
{
    public class ArchiveEntity
    {
        [Key]
        public int ArchiveId { get; set; }

        // Foreign key to relate event with user
        public Guid Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        // Foreign key to relate event with Activity
        public int ActivityId { get; set; }

        public ActivityEntity ActivityEntity { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
