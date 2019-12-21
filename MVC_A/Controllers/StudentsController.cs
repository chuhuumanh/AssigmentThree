using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_A.Models;
using MVC_A.ViewModels;

namespace MVC_A.Controllers
{
    public class StudentsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Students
        public ActionResult Index()
        {
            var listStudents = new List<StudentViewModel>();
            db.Students.ToList().ForEach(student =>
            {
                listStudents.Add(new StudentViewModel(student.Id, student.ClassId, student.Code, student.Name, student.Phone,student.Email));
            });
            return View(listStudents);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            StudentViewModel studentViewModel = new StudentViewModel(student.Id, student.ClassId, student.Code, student.Name, student.Phone, student.Email);
            return View(studentViewModel);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            EditStudentViewModel editStudentViewModel = new EditStudentViewModel();
            return View(editStudentViewModel);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,Code,Name,Phone,Email")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            EditStudentViewModel editStudentViewModel = new EditStudentViewModel(student.Id, student.ClassId, student.Code, student.Name, student.Phone, student.Email);
            return View(editStudentViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,Code,Name,Phone,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            StudentViewModel delModel = new StudentViewModel(student.Id, student.ClassId, student.Code, student.Name, student.Phone, student.Email);
            return View(delModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
