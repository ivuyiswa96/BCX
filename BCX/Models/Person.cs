using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class Person
    {
       // [ForeignKey("UserId")]
       [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public Gender Gender { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

   public enum Gender {
        Male,Female
    }
}
