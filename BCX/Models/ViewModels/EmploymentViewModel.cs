using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models.ViewModels
{
    public class EmploymentViewModel
    {
        public string EmpCode { get; set; }
        public string JobDescription { get; set; }
        public double Salary { get; set; }
        public double RatePerHour { get; set; }
        public int HourWorked { get; set; }
        public virtual LevelType LevelType { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string CompanyName { get; set; }
        public JobTitle JobTitle { get; set; }
        public string EmploymentType { get; set; }
       // public string Description { get; set; }
        public int PersonId { get; set; }
        public int TaskTypeId { get; set; }

        public int EmployeeId { get; set; }
        public int LevelTypeId { get; set; }

    }
}
