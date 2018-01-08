using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWheels.Models
{
    public class ActivityListItem
    {
        [Key]
        public int ActivityId { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }
    }
}
