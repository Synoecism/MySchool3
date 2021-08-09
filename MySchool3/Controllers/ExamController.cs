using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool3.Controllers
{
    public class ExamController : Controller
    {
        public ViewResult ExamOne()
        {
            ViewBag.title = "Exam One - My school";
            return View();
        }
        public ViewResult ExamTwo()
        {
            ViewBag.title = "Exam Two - My School";
            return View();
        }
        public ViewResult ExamThree()
        {
            ViewBag.title = "Exam Three - My School";
            return View();
        }
    }
}
