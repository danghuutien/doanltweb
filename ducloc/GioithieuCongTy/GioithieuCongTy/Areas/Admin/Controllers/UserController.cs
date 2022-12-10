using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private GioithieuContext db = new GioithieuContext();
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajax(string searchnow)
        {
            if (searchnow == "")
            {
                var data = db.Users.ToList();
                

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Users.Where(i => i.Fullname.Contains(searchnow)).ToList();
                
                return Json(data, JsonRequestBehavior.AllowGet);

            }

        }

   
        [HttpPost]
        public ActionResult Delete(int id)
        {
            User Menu = db.Users.Find(id);
            db.Users.Remove(Menu);
            db.SaveChanges();
            return Json(new { status = true });
        }


        /*public ActionResult ajaxDanhmuc()
        {
             return 
        }*/

        [HttpPost]
        public ActionResult Edit(string Fullname, string Gmail, string Password, double Phone, int id)
        {
            try
            {
                User User = db.Users.Find(id);
                User.Fullname = Fullname;
                User.Gmail = Gmail;
                User.Phone = Phone;
                User.Password = Password;
                User.Created_at = DateTime.Now;
                
               

                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(string Fullname, string Gmail, string Password, double Phone)
        {
            try
            {
                User User = new User();
                User.Fullname = Fullname;
                User.Gmail = Gmail;
                User.Phone = Phone;
                User.Password = Password;
                User.Created_at = DateTime.Now;
                db.Users.Add(User);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }

    }
}