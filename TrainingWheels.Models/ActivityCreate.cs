using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWheels.Models
{
    public class ActivityCreate
    {
        [Key]
        public int ActivityId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Category { get; set; }

        public int Score { get; set; }
    }
}
