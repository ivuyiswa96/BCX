using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models.ViewModels
{
    public class TaskViewModel
    {

        public double RatePerHour { get; set; }
        public int HourWorked { get; set; }
        public int TaskTypeId { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public virtual LevelType LevelType { get; set; }

    }
}
