using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class RegistrationViewModel
    {
        [Required,EmailAddress,MaxLength(256)]
        public string Email { get; set; }
        [Required,DataType(DataType.Password),MinLength(6),MaxLength(50)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), MinLength(6), MaxLength(50),Compare("Password",ErrorMessage ="The password doesn't match ")]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }
        public string UserId { get; set; }
    }
}
