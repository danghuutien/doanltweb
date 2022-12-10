using GioithieuCongTy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gioithieudaihocvinh.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Admin/Question
        public ActionResult Index()
        {
            return View();
        }
    }
}