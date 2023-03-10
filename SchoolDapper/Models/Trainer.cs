using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public int? CourseId { get; set; }
        public DateTime? Birthdate { get; set; }
        public string City { get; set; }

        public virtual Course Course { get; set; }
    }
}
