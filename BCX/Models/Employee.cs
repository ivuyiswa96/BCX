using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class Employee
    {
       // [ForeignKey("Person")]
        [Key]
        public int EmployeeId { get; set; }
        public string EmpCode { get; set; }
        public string JobDescription { get; set; }
        public double Salary { get; set; }
        public double RatePerHour { get; set; }
        public int HourWorked { get; set; }
        public int EmployerId { get; set; }
        public int LevelTypeId { get; set; }
        public int PersonId { get; set; }
        //public virtual Employer Employer { get; set; }
        public virtual Person Person { get; set; }
        public virtual LevelType LevelType { get; set; }
    }

   
}
