using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWheels.Data
{
    public class ActivityEntity
    {
        [Key]
        public int ActivityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
