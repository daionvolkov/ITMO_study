using StudentsDairyMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentsDairyMVC.Controllers
{
    public class HomeController : Controller
    {
        StudentsDB db = new StudentsDB();

        public ActionResult Index()
        {
    
            return View(db.Students);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student s = db.Students.Find(id);
            return View(s);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConf(int id)
        {

            Student s = db.Students.Find(id);
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }


        [HttpPost]
        public string Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Данные изменены";
            }
            return "Данные не изменены";

        }

        [HttpGet]
        public ActionResult Show(int? id)
        {
            Score score = db.Scores.Find(id);
            return View(score);

        }
        [HttpGet]
        public ActionResult FiveBest()
        {
            List<Student> student = new List<Student>();
            using (StudentsDB db1 = new StudentsDB())
            {
                student = db1.Students.OrderByDescending(x => x.ScoreId).ThenBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            }
            return View(student);
        }
        [HttpGet]
        public ActionResult FiveWorst()
        {
            List<Student> student = new List<Student>();
            using (StudentsDB db1 = new StudentsDB())
            {
                student = db1.Students.OrderBy(x => x.ScoreId).ThenBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            }
            return View(student);
        }

    }
}