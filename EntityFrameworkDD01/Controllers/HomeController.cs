using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EntityFrameworkDD01.Models;

namespace EntityFrameworkDD01.Controllers
{

    public class HomeController : Controller
    {
        StudentContext db= new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
    }
}