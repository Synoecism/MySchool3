using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MySchool3.Models;
using MySchool3.Infrastructure;

namespace MySchool3.Controllers
{
    public class HomeController : Controller

    {
        private ISchoolRepository repository;

        //constructor
        //in the controller, only use the interface to the repository
        public HomeController(ISchoolRepository repo)
        {
            repository = repo;
        }

        // called in _Mainlayout navigation
        public ViewResult Index()
        {
            //change title of web browser tab
            ViewBag.title = "Home - My School";
            return View();
        }

        [HttpPost]
        public ViewResult Index(Student student)
        {
            ViewBag.Name = $"Välkommen {student.Name}";
            return View("NewStudent");
        }

        public ViewResult Roster()
        {
            //change title of web browser tab
            ViewBag.title = "Roster - My School";

            //try to aim for only passing limited amount of information
            //this adds/enables data to the view
            return View(repository);
        }

        public ViewResult Courses()
        {
            //change title of web browser tab
            ViewBag.title = "Courses - My School";
            return View(repository.Courses);
        }

        public ViewResult Cookies()
        {
            //change title of web browser tab
            ViewBag.title = "Cookies - My School";
            return View();
        }

        public ViewResult WriteCookies(string setting, string settingValue, bool isPersistent)
        {

            if (isPersistent)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(setting, WebUtility.UrlEncode(settingValue), options);
            }
            else
            {
                Response.Cookies.Append(setting, WebUtility.UrlEncode(settingValue));
            }
            ViewBag.Message = "Cookie written succesfully!";
            return View("Cookies");
        }

        public ViewResult ReadCookie()
        {
            ViewBag.FontName = WebUtility.UrlDecode(Request.Cookies["fontName"]);
            ViewBag.FontSize = WebUtility.UrlDecode(Request.Cookies["fontSize"]);
            ViewBag.FontColor = WebUtility.UrlDecode(Request.Cookies["fontColor"]);

            if (string.IsNullOrEmpty(ViewBag.FontName))
            {
                ViewBag.FontName = "Arial";
            }
            if (string.IsNullOrEmpty(ViewBag.FontSize))
            {
                ViewBag.FontSize = "22px";
            }
            if (string.IsNullOrEmpty(ViewBag.FontColor))
            {
                ViewBag.FontColor = "Blue";
            }

            return View();

        }

        public ViewResult Exam()
        {
            //change title of web browser tab
            ViewBag.title = "Exam - My School";
            return View();
        }

        public ViewResult ShowTeacherInfo(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ViewResult ShowStudentInfo(int id)
        {
            var studentDetail = repository.GetStudentDetail(id);
            return View(studentDetail);
        }

        public ViewResult NewStudent(string fullname)
        {
            ViewBag.Name = fullname;
            return View();
        }

        public ViewResult Customers()
        {
            ViewBag.Name = "Customers - My School??";

            var myCustomer = HttpContext.Session.GetJson<Customer>("NewCustomer");
            if (myCustomer == null)
            {
                return View();
            }
            else
            {
                return View(myCustomer);
            }
        }

        [HttpPost]
        public ViewResult ValidateCustomer(Customer cust)
        {
            HttpContext.Session.SetJson("NewCustomer", cust);
            return View(cust);
        }

        public ViewResult SavedCustomer()
        {
            //here lies the call to persistent storage

            //always destroy session after call to persistent
            HttpContext.Session.Remove("NewCustomer");
            return View();
        }
    }
}
