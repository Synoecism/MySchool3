using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool3.Models
{
    public class FakeSchoolRepository : ISchoolRepository
    {
        public IQueryable<Student> Students => new List<Student>
        {
            new Student {StudentID = 2, Name = "Mannelito", Code = "CDF", EnrollmentNumber = 20},
            new Student {StudentID = 1, Name = "Karl", Code = "ABC", EnrollmentNumber = 10},
            new Student {StudentID = 3, Name = "Sebban", Code = "FGH", EnrollmentNumber = 30}

        }.AsQueryable<Student>();

        public IQueryable<Teacher> Teachers => new List<Teacher>
        {
              new Teacher {TeacherID = 1, Name = "Lärare 1", Code = "ABC"},
              new Teacher {TeacherID = 2, Name = "RPQ", Code = "ABC"},
              new Teacher {TeacherID = 3, Name = "Lets go", Code = "ABC"}

        }.AsQueryable<Teacher>();

        //used to get only a certain teacher info
        //linq-expression used
        /*
        public IQueryable<Teacher> GetTeacherDetail(int id)
        {
            // linq expression
            var teacherDetail = from td in Teachers
                                where td.TeacherID == id
                                select td;
            return teacherDetail; // returns a list
        }
        */
        public Student GetStudentDetail(int id)
        {
            // method expression (returns a single object)
            return Students.Where(st => st.StudentID == id).First();
        }

        public Task<Teacher> GetTeacherDetail(int id)
        {
            //task will put call on queue, therefore, can be used in async
            return Task.Run(() =>
            {
                var teacherDetail = Teachers.Where(td => td.TeacherID == id).First();
                return teacherDetail;
            }
            );
        }

        public IQueryable<Course> Courses => new List<Course>
        {
              new Course {CourseID = 1, Name = "Computer science", CourseCode = "ABC"},
                            new Course {CourseID = 1, Name = "Statistics", CourseCode = "ASF"},


        }.AsQueryable<Course>();
    }
}
