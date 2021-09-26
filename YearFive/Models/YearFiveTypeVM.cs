using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YearFive.Models
{
    public class YearFiveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "State of Origin")]
        public string StateOfOrigin { get; set; }
        [Required]
        [Display(Name = "Date Started")]
        public DateTime StartDate { get; set; }
    }
}
