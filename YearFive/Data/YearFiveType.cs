﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YearFive.Data
{
    public class YearFiveType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string StateOfOrigin { get; set; }
        public DateTime StartDate { get; set; }
    }
}
