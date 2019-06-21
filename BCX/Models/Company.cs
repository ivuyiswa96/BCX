using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public JobTitle JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
    public enum JobTitle {
        IT,Engineer,HR,Manager
    }
}
