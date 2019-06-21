using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class TaskType
    {
        public int TaskTypeId { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        //public DateTime TaskDate { get; set; }
        public double RatePerHour { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
