using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySchool3.Models
{
    // this is called a POCO class
    public class Student
    {
        public int StudentID { set; get; }
        public string Code { set; get; }
        [Display(Name = "Complete name")]
        [Required(ErrorMessage = "Wrong input")]
        public string Name { set; get; }
        public int EnrollmentNumber { set; get; }
    }
}
