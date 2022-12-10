using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private GioithieuContext db = new GioithieuContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Check(string Gmail, string password)
        {
            try
            {
                var User = db.Users.Where(i=>i.Gmail.Equals(Gmail) && i.Password.Equals(password)).ToList();
                if(User.Count() > 0)
                {
                    return Json(new { status = true });
                }
                else
                {
                    return Json(new { status = false });

                }

            }
            catch (InvalidCastException e)
            {
                return Json(new { satus = e.Message });
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }

    }
}