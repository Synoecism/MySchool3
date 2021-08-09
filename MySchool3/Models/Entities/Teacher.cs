using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// do not forget to remove .Entities
// namesspace MySchool3.Models.Entities
namespace MySchool3.Models
{
    public class Teacher
    {
        public int TeacherID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
    }
}
