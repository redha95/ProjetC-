using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (SchoolContext context = new SchoolContext())
            {
                context.Students.Add(new Student {
                     Height=184,
                     DateOfBirth = DateTime.Now,
                     StudentName = "Redha le boss de l'équipe",
                     StudentID = 1
                });
                List<Student> result = context.Students.ToList();
                var x = result;
            }
            return View();
        }
    }
}