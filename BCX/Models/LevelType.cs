using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.Models
{
    public class LevelType
    {
        [Key]
        public int LevelTypeId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
