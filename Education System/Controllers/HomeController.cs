using Education_System.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Education_System.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        List<Course> li = new List<Course>();
        List<cart> li1 = new List<cart>();
        public async Task<ActionResult> Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Mymodel CS = new Mymodel();
            CS.CourseList = db.Courses.ToList();
            return View(CS);
            //return View();
        }
        public ActionResult search1(string search)
        {
            var ys = (db.Courses.Where(pro => pro.Name.Contains(search) || search == null).ToList());
            
            return View(ys);
        }
            public ActionResult CourseDetail(int id)
        {
            return View(db.Courses.Where(s => s.id == id).FirstOrDefault());
            
        }
        [Authorize(Roles = "User")]
        public ActionResult cart()
        {
            //string email = Session["Email"].ToString();
            string email = User.Identity.GetUserName().ToString();
            var na = db.carts.Where(x => x.Cemail == email).ToList();
            return View(na);
        }
        public ActionResult addtocart(int id, int qty)
        {
            Course tf = db.Courses.Where(s => s.id == id).FirstOrDefault();

            if (User.Identity.GetUserName() != null)
            {
                string email = User.Identity.GetUserName().ToString();
                cart c = new cart();
                c.Cemail = email;
                c.Cid = id;
                c.name = tf.Name;
                c.price = Convert.ToInt32(tf.Price);
                c.image = tf.Image;
                c.qty = Convert.ToInt32(qty);

                c.bil = c.price * c.qty;

                db.carts.Add(c);
                db.SaveChanges();
            }
            else
            {
                TempData["msg1"] = "You Are Not Logged In The System";

            }

            return RedirectToAction("cart");
        }
        public ActionResult Delete(int id)
        {

            var del = db.carts.Find(id);
            db.carts.Remove(del);
            db.SaveChanges();
            return RedirectToAction("cart");
        }
        //public ActionResult CourseDetail()
        //{

        //    return View();
        //}
        [Authorize(Roles =Role.RoleAdmin)]
        public ActionResult Adminarea()
        {

            return View();
        }

        [Authorize(Roles = Role.RoleUser)]
        public ActionResult Userarea()
        {

            return View();
        }
       
    }
}