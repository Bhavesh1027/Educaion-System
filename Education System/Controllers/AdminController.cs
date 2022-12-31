using Education_System.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Education_System.Controllers
{
    public class AdminController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Course()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Course(Course course)
        {
            //if(ModelState.IsValid)
            //{
            if (course.ImageFile != null)
            {
                string ImageName = Path.GetFileName(course.ImageFile.FileName);
                string Ppath = Server.MapPath("~/Images/course/" + ImageName);
                course.ImageFile.SaveAs(Ppath);
                course.Image = "~/Images/course/" + ImageName;
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Admin_Course");
            }

            //}
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin_Edit(/*string id*/)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Course c = db.Courses.Find(id);
            //if (c == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(c);
            return View();    
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        //public ActionResult Course_edit()
        //{
        //    return View();
        //}
        public ActionResult Course_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Course_edit([Bind(Include = "id,Name,Description,Course_Details,Category,Requirements,Course_Syllabus,Credits,Duration,Lessons,seats,Image,Price")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Sidebar()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin_Nav()
        {
            return View();
        }
        public ActionResult Course_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        public ActionResult Course_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Course_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin_User()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //RegisterViewModel CS = new RegisterViewModel();

            //db.ApplicationUsers.ToList();
            return View();
            //return View(db.applicationUsers.ToList());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin_Course(int? page)
        {
            int pageSize = 7;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            return View(db.Courses.ToList().ToPagedList(pageIndex, pageSize));
        }
    }
}
        