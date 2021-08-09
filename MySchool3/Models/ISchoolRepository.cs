using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool3.Models
{
    public interface ISchoolRepository
    {
        //Iqueryable is used when getting info from persistent storage (sql calls)
        IQueryable<Student> Students { get; }
        IQueryable<Teacher> Teachers { get; }
        Task<Teacher> GetTeacherDetail(int id);
        Student GetStudentDetail(int id);
        IQueryable<Course> Courses { get; }
    }
}
