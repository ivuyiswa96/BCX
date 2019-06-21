using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class Employer
    {
       [Key]
        public int EmployerId { get; set; }
        public string  StaffCode { get; set; }

       // ICollection<Employee> Employee { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
