using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Roll_No { get; set; }
    }
}
