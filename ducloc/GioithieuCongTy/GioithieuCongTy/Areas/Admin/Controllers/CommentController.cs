using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        // GET: Admin/Comment

        private GioithieuContext db = new GioithieuContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ajax(string searchnow)
        {
            if (searchnow == "")
            {
                var data = db.Comments.ToList();


                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Comments.Where(i => i.Content.Contains(searchnow)).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);

            }

        }
    }
}