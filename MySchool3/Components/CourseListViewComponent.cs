using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySchool3.Models;
using Microsoft.AspNetCore.Mvc;

namespace MySchool3.Components
{
    public class CourseListViewComponent : ViewComponent
    {
        private ISchoolRepository repository;

        public CourseListViewComponent(ISchoolRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View("CourseList", repository.Courses);
        }
    }
}
