using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySchool3.Models;

namespace MySchool3.Components
{
    public class ShowOneTeacher : ViewComponent
    {
        private ISchoolRepository repository;

        public ShowOneTeacher(ISchoolRepository repo)
        {
            repository = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var teacherDetail = await repository.GetTeacherDetail(id);
            return View(teacherDetail);
        }
    }

}
