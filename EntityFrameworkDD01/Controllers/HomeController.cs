using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid == true)
            {

            db.Students.Add(s);
            int a =  db.SaveChanges();
            if(a> 0)
            {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted!!')</script>";
                    TempData["InsertMessage"] = "Data Inserted";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
            else
            {
                ViewBag.InsertMessage = "<script>alert('Data Not Inserted!!')</script>";
            }
            }
                return View();
        }

        public ActionResult Edit(int id)
        {

            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {

            db.Entry(s).State = EntityState.Modified;
            int a = db.SaveChanges();
            if(a > 0)
            {
                //ViewBag.UpdateMessage = "<script>alert('Data Updated!!')</script>";
                //TempData["UpdateMessage"] = "<script>alert('Data Updated!!')</script>";
                TempData["UpdateMessage"] = "Data Updated!!";

                return RedirectToAction("Index");

                //ModelState.Clear();
            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data Not Updated!!')</script>";
            }
                return View();
        }

    }

}